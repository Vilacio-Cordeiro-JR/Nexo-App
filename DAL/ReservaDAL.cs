using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Nexo_App.Models;

namespace Nexo_App.DAL
{
    /// <summary>
    /// Data Access Layer responsável pelas operações de persistência relacionadas a Reservas.
    /// Centraliza a criação de reservas associadas a assentos específicos e a listagem consolidada para relatórios e painéis.
    /// </summary>
    public class ReservaDAL
    {
        /// <summary>
        /// Insere uma nova reserva no sistema, vincula os assentos selecionados e atualiza o status deles para ocupado.
        /// Decisão: Toda a operação é executada sob uma transação de banco de dados (tudo ou nada) para garantir a integridade dos dados e evitar reservas fantasmas ou assentos duplicados.
        /// </summary>
        /// <param name="cdUsuario">Código do usuário que está realizando a reserva.</param>
        /// <param name="cdViagem">Código da viagem desejada.</param>
        /// <param name="cdAssentos">Lista com os códigos dos assentos que serão vinculados à reserva.</param>
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

            // Decisão: Uso do bloco 'using' para garantir o fechamento seguro da conexão e descarte correto de recursos.
            using (var con = Conexao.Abrir())
            using (var trans = con.BeginTransaction()) // Início da transação de segurança
            {
                try
                {
                    int cdReserva;
                    using (var cmd = new SqlCommand(sqlReserva, con, trans))
                    {
                        cmd.Parameters.AddWithValue("@cd_usuario", cdUsuario);
                        cmd.Parameters.AddWithValue("@cd_viagem", cdViagem);
                        cdReserva = (int)cmd.ExecuteScalar();
                    }

                    // Loop para vincular cada assento da lista à reserva criada e alterar sua disponibilidade
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

                    trans.Commit(); // Confirma todas as alterações se nenhuma falha ocorrer
                }
                catch
                {
                    trans.Rollback(); // Desfaz completamente a operação em caso de qualquer erro no processo
                    throw;
                }
            }
        }

        /// <summary>
        /// Recupera a lista completa de todas as reservas do sistema com informações consolidadas através de INNER JOINs.
        /// Decisão: Utiliza a função STRING_AGG para agrupar e formatar os números dos assentos em uma única string, ideal para exibição direta em componentes como o DataGrid do painel administrativo.
        /// </summary>
        /// <returns>Uma lista de objetos <see cref="Reserva"/> contendo os dados relacionados de usuários, viagens e assentos ocupados.</returns>
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
                ORDER BY r.cd_reserva DESC"; // Ordena pelas mais recentes no topo do painel

            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    lista.Add(new Reserva
                    {
                        CdReserva = (int)r["cd_reserva"],
                        NmUsuario = (string)r["nm_usuario"],
                        NmOrigem = (string)r["nm_origem"],
                        NmDestino = (string)r["nm_destino"],
                        DtReserva = (DateTime)r["dt_viagem"],
                        IcStatus = (string)r["ic_status"],
                        Assentos = (string)r["assentos"]
                    });
                }
            }
            return lista;
        }
    }
}