using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Nexo_App.Models;

namespace Nexo_App.DAL
{
    public class ViagemDAL
    {
        // Lista viagens aplicando filtros opcionais e conferindo o horário da aplicação
        public List<Viagem> ListarDisponiveis(string origem = null, string destino = null, DateTime? data = null)
        {
            var lista = new List<Viagem>();

            // Query base com os Joins necessários
            string sql = @"
                SELECT
                    v.cd_viagem,
                    v.nm_origem,
                    v.nm_destino,
                    v.dt_viagem,
                    v.vl_preco,
                    COUNT(a.cd_assento) AS qt_livres
                FROM Viagem v
                    LEFT JOIN Assento a ON a.cd_viagem = v.cd_viagem AND a.ic_status = 'LIVRE'
                WHERE v.dt_viagem > @dt_atual ";

            // Concatenação dinâmica de filtros textuais ou de data
            if (!string.IsNullOrWhiteSpace(origem))
                sql += " AND v.nm_origem = @origem ";

            if (!string.IsNullOrWhiteSpace(destino))
                sql += " AND v.nm_destino = @destino ";

            if (data.HasValue)
                sql += " AND CAST(v.dt_viagem AS DATE) = CAST(@data AS DATE) ";

            sql += @" GROUP BY v.cd_viagem, v.nm_origem, v.nm_destino, v.dt_viagem, v.vl_preco
                      HAVING COUNT(a.cd_assento) > 0
                      ORDER BY v.dt_viagem";

            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
            {
                // Parâmetro base temporal seguro
                cmd.Parameters.AddWithValue("@dt_atual", DateTime.Now);

                if (!string.IsNullOrWhiteSpace(origem))
                    cmd.Parameters.AddWithValue("@origem", origem);

                if (!string.IsNullOrWhiteSpace(destino))
                    cmd.Parameters.AddWithValue("@destino", destino);

                if (data.HasValue)
                    cmd.Parameters.AddWithValue("@data", data.Value);

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new Viagem
                        {
                            CdViagem = (int)r["cd_viagem"],
                            NmOrigem = (string)r["nm_origem"],
                            NmDestino = (string)r["nm_destino"],
                            DtViagem = (DateTime)r["dt_viagem"],
                            VlPreco = (decimal)r["vl_preco"],
                            QtLivres = (int)r["qt_livres"]
                        });
                    }
                }
            }
            return lista;
        }

        // Mantém o método Inserir inalterado...
        public void Inserir(Viagem v, int qtAssentos)
        {
            string sqlViagem = @"
                INSERT INTO Viagem (nm_origem, nm_destino, dt_viagem, vl_preco)
                OUTPUT INSERTED.cd_viagem
                VALUES (@nm_origem, @nm_destino, @dt_viagem, @vl_preco)";

            using (var con = Conexao.Abrir())
            {
                int cdViagem;
                using (var cmd = new SqlCommand(sqlViagem, con))
                {
                    cmd.Parameters.AddWithValue("@nm_origem", v.NmOrigem);
                    cmd.Parameters.AddWithValue("@nm_destino", v.NmDestino);
                    cmd.Parameters.AddWithValue("@dt_viagem", v.DtViagem);
                    cmd.Parameters.AddWithValue("@vl_preco", v.VlPreco);
                    cdViagem = (int)cmd.ExecuteScalar();
                }

                string sqlAssento = "INSERT INTO Assento (qt_numero, cd_viagem) VALUES (@num, @cd_viagem)";
                using (var cmdAssento = new SqlCommand(sqlAssento, con))
                {
                    cmdAssento.Parameters.Add("@num", System.Data.SqlDbType.Int);
                    cmdAssento.Parameters.AddWithValue("@cd_viagem", cdViagem);

                    for (int i = 1; i <= qtAssentos; i++)
                    {
                        cmdAssento.Parameters["@num"].Value = i;
                        cmdAssento.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    public class AssentoDAL
    {
        // Retorna todos os assentos de uma viagem
        public List<Assento> ListarPorViagem(int cdViagem)
        {
            var lista = new List<Assento>();
            string sql = @"
                SELECT cd_assento, qt_numero, cd_viagem, ic_status
                FROM   Assento
                WHERE  cd_viagem = @cd_viagem
                ORDER BY qt_numero";

            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@cd_viagem", cdViagem);
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        lista.Add(new Assento
                        {
                            CdAssento = (int)r["cd_assento"],
                            QtNumero = (int)r["qt_numero"],
                            CdViagem = (int)r["cd_viagem"],
                            IcStatus = (string)r["ic_status"]
                        });
            }
            return lista;
        }

        public void MarcarOcupado(int cdAssento)
        {
            string sql = "UPDATE Assento SET ic_status = 'OCUPADO' WHERE cd_assento = @cd_assento";
            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@cd_assento", cdAssento);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
