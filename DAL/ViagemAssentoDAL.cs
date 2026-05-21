using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Nexo_App.Models;

namespace Nexo_App.DAL
{
    public class ViagemAssentoDAL
    {
        /// <summary>
        /// LISTAR TODAS: Retorna o histórico completo sem travas de data ou lotação. Perfeito para o Admin.
        /// </summary>
        public List<Viagem> ListarTodas()
        {
            var lista = new List<Viagem>();
            string sql = @"
                SELECT
                    v.cd_viagem,
                    v.nm_origem,
                    v.nm_destino,
                    v.dt_viagem,
                    v.vl_preco,
                    v.ds_imagem,
                    COUNT(CASE WHEN a.ic_status = 'LIVRE' THEN 1 END) AS qt_livres
                FROM Viagem v
                    LEFT JOIN Assento a ON a.cd_viagem = v.cd_viagem
                GROUP BY v.cd_viagem, v.nm_origem, v.nm_destino, v.dt_viagem, v.vl_preco, v.ds_imagem
                ORDER BY v.dt_viagem DESC"; // Mais recentes primeiro no painel

            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
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
                        DsImagem = r["ds_imagem"] != DBNull.Value ? (string)r["ds_imagem"] : null,
                        QtLivres = (int)r["qt_livres"]
                    });
                }
            }
            return lista;
        }

        /// <summary>
        /// LISTAR DISPONÍVEIS: Filtrado para a busca do cliente final na rodoviária.
        /// </summary>
        public List<Viagem> ListarDisponiveis(string origem = null, string destino = null, DateTime? data = null)
        {
            var lista = new List<Viagem>();

            string sql = @"
                SELECT
                    v.cd_viagem,
                    v.nm_origem,
                    v.nm_destino,
                    v.dt_viagem,
                    v.vl_preco,
                    v.ds_imagem,
                    COUNT(a.cd_assento) AS qt_livres
                FROM Viagem v
                    LEFT JOIN Assento a ON a.cd_viagem = v.cd_viagem AND a.ic_status = 'LIVRE'
                WHERE v.dt_viagem > @dt_atual ";

            if (!string.IsNullOrWhiteSpace(origem))
                sql += " AND v.nm_origem = @origem ";

            if (!string.IsNullOrWhiteSpace(destino))
                sql += " AND v.nm_destino = @destino ";

            if (data.HasValue)
                sql += " AND CAST(v.dt_viagem AS DATE) = CAST(@data AS DATE) ";

            sql += @" GROUP BY v.cd_viagem, v.nm_origem, v.nm_destino, v.dt_viagem, v.vl_preco, v.ds_imagem
                     HAVING COUNT(a.cd_assento) > 0
                     ORDER BY v.dt_viagem";

            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
            {
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
                            DsImagem = r["ds_imagem"] != DBNull.Value ? (string)r["ds_imagem"] : null,
                            QtLivres = (int)r["qt_livres"]
                        });
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// INSERIR (CREATE): Salva a viagem e gera os assentos sob segurança de uma Transação.
        /// </summary>
        public void Inserir(Viagem v, int qtAssentos)
        {
            string sqlViagem = @"
                INSERT INTO Viagem (nm_origem, nm_destino, dt_viagem, vl_preco, ds_imagem)
                OUTPUT INSERTED.cd_viagem
                VALUES (@nm_origem, @nm_destino, @dt_viagem, @vl_preco, @ds_imagem)";

            using (var con = Conexao.Abrir())
            using (var transacao = con.BeginTransaction()) // Início da transação de segurança
            {
                try
                {
                    int cdViagem;
                    using (var cmd = new SqlCommand(sqlViagem, con, transacao))
                    {
                        cmd.Parameters.AddWithValue("@nm_origem", v.NmOrigem);
                        cmd.Parameters.AddWithValue("@nm_destino", v.NmDestino);
                        cmd.Parameters.AddWithValue("@dt_viagem", v.DtViagem);
                        cmd.Parameters.AddWithValue("@vl_preco", v.VlPreco);
                        cmd.Parameters.AddWithValue("@ds_imagem", string.IsNullOrWhiteSpace(v.DsImagem) ? (object)DBNull.Value : v.DsImagem);

                        cdViagem = (int)cmd.ExecuteScalar();
                    }

                    string sqlAssento = "INSERT INTO Assento (qt_numero, cd_viagem, ic_status) VALUES (@num, @cd_viagem, 'LIVRE')";
                    using (var cmdAssento = new SqlCommand(sqlAssento, con, transacao))
                    {
                        cmdAssento.Parameters.Add("@num", SqlDbType.Int);
                        cmdAssento.Parameters.AddWithValue("@cd_viagem", cdViagem);

                        for (int i = 1; i <= qtAssentos; i++)
                        {
                            cmdAssento.Parameters["@num"].Value = i;
                            cmdAssento.ExecuteNonQuery();
                        }
                    }

                    transacao.Commit(); // Se tudo correu bem, salva definitivamente
                }
                catch
                {
                    transacao.Rollback(); // Desfaz tudo se houver qualquer erro de execução
                    throw;
                }
            }
        }

        /// <summary>
        /// ALTERAR (UPDATE): Atualiza os dados cadastrais da rota.
        /// </summary>
        public void Alterar(Viagem v)
        {
            string sql = @"
                UPDATE Viagem 
                SET nm_origem = @nm_origem, 
                    nm_destino = @nm_destino, 
                    dt_viagem = @dt_viagem, 
                    vl_preco = @vl_preco, 
                    ds_imagem = @ds_imagem
                WHERE cd_viagem = @cd_viagem";

            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@cd_viagem", v.CdViagem);
                cmd.Parameters.AddWithValue("@nm_origem", v.NmOrigem);
                cmd.Parameters.AddWithValue("@nm_destino", v.NmDestino);
                cmd.Parameters.AddWithValue("@dt_viagem", v.DtViagem);
                cmd.Parameters.AddWithValue("@vl_preco", v.VlPreco);
                cmd.Parameters.AddWithValue("@ds_imagem", string.IsNullOrWhiteSpace(v.DsImagem) ? (object)DBNull.Value : v.DsImagem);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// EXCLUIR (DELETE): Exclui assentos e viagem em cascata protegidos por transação.
        /// </summary>
        public void Excluir(int cdViagem)
        {
            using (var con = Conexao.Abrir())
            using (var transacao = con.BeginTransaction())
            {
                try
                {
                    string sqlAssentos = "DELETE FROM Assento WHERE cd_viagem = @id";
                    using (var cmd = new SqlCommand(sqlAssentos, con, transacao))
                    {
                        cmd.Parameters.AddWithValue("@id", cdViagem);
                        cmd.ExecuteNonQuery();
                    }

                    string sqlViagem = "DELETE FROM Viagem WHERE cd_viagem = @id";
                    using (var cmd = new SqlCommand(sqlViagem, con, transacao))
                    {
                        cmd.Parameters.AddWithValue("@id", cdViagem);
                        cmd.ExecuteNonQuery();
                    }

                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Classe separada corretamente para evitar problemas de escopo no projeto
        /// </summary>
        public class AssentoDAL
        {
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
                    {
                        while (r.Read())
                        {
                            lista.Add(new Assento
                            {
                                CdAssento = (int)r["cd_assento"],
                                QtNumero = (int)r["qt_numero"],
                                CdViagem = (int)r["cd_viagem"],
                                IcStatus = (string)r["ic_status"]
                            });
                        }
                    }
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
}