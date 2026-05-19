using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Nexo_App.Models;

namespace Nexo_App.DAL
{
    public class ReservaDAL
    {
        // Cria reserva e os assentos vinculados — tudo numa transação
        public void Inserir(int cdUsuario, int cdViagem, List<int> cdAssentos)
        {
            string sqlReserva = @"
                INSERT INTO Reserva (cd_usuario, cd_viagem, ic_status)
                OUTPUT INSERTED.cd_reserva
                VALUES (@cd_usuario, @cd_viagem, 'PAGA')";

            string sqlReservaAssento = @"
                INSERT INTO ReservaAssento (cd_reserva, cd_assento)
                VALUES (@cd_reserva, @cd_assento)";

            string sqlOcupar = "UPDATE Assento SET ic_status = 'OCUPADO' WHERE cd_assento = @cd_assento";

            using (var con = Conexao.Abrir())
            using (var trans = con.BeginTransaction()) // transação: tudo ou nada
            {
                try
                {
                    int cdReserva;
                    using (var cmd = new SqlCommand(sqlReserva, con, trans))
                    {
                        cmd.Parameters.AddWithValue("@cd_usuario", cdUsuario);
                        cmd.Parameters.AddWithValue("@cd_viagem",  cdViagem);
                        cdReserva = (int)cmd.ExecuteScalar();
                    }

                    foreach (int cdAssento in cdAssentos)
                    {
                        using (var cmd = new SqlCommand(sqlReservaAssento, con, trans))
                        {
                            cmd.Parameters.AddWithValue("@cd_reserva", cdReserva);
                            cmd.Parameters.AddWithValue("@cd_assento", cdAssento);
                            cmd.ExecuteNonQuery();
                        }

                        using (var cmd = new SqlCommand(sqlOcupar, con, trans))
                        {
                            cmd.Parameters.AddWithValue("@cd_assento", cdAssento);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback(); // se der erro, desfaz tudo
                    throw;
                }
            }
        }

        // Lista todas as reservas com JOIN — para o DataGrid do admin
        public List<Reserva> ListarTodas()
        {
            var lista = new List<Reserva>();
            string sql = @"
                SELECT
                    r.cd_reserva,
                    u.nm_usuario,
                    v.nm_origem,
                    v.nm_destino,
                    v.dt_viagem,
                    r.ic_status,
                    STRING_AGG(CAST(a.qt_numero AS VARCHAR), ', ') AS assentos
                FROM Reserva r
                    INNER JOIN Usuario        u  ON r.cd_usuario  = u.cd_usuario
                    INNER JOIN Viagem         v  ON r.cd_viagem   = v.cd_viagem
                    INNER JOIN ReservaAssento ra ON ra.cd_reserva = r.cd_reserva
                    INNER JOIN Assento        a  ON ra.cd_assento = a.cd_assento
                GROUP BY
                    r.cd_reserva, u.nm_usuario,
                    v.nm_origem, v.nm_destino, v.dt_viagem, r.ic_status
                ORDER BY r.cd_reserva DESC";

            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                    lista.Add(new Reserva
                    {
                        CdReserva  = (int)     r["cd_reserva"],
                        NmUsuario  = (string)  r["nm_usuario"],
                        NmOrigem   = (string)  r["nm_origem"],
                        NmDestino  = (string)  r["nm_destino"],
                        DtReserva  = (DateTime)r["dt_viagem"],
                        IcStatus   = (string)  r["ic_status"],
                        Assentos   = (string)  r["assentos"]
                    });
            }
            return lista;
        }
    }
}
