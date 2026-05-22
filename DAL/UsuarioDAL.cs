using System.Collections.Generic;
using System.Data.SqlClient;
using Nexo_App.Models;

namespace Nexo_App.DAL
{
    /// <summary>
    /// Data Access Layer responsável pelas operações de persistência e consulta de dados do usuário.
    /// Centraliza o acesso ao banco para garantir baixo acoplamento e facilitar manutenção.
    /// </summary>
    public class UsuarioDAL
    {
        /// <summary>
        /// Insere um novo usuário no banco de dados.
        /// Decisão: Uso do bloco 'using' garante liberação imediata da conexão, evitando leaks e exaustão do pool.
        /// </summary>
        /// <param name="u">Objeto usuário preenchido.</param>
        public void Inserir(Usuario u)
        {
            string sql = @"
                INSERT INTO Usuario
                    (nm_usuario, nm_email, ds_senha_hash, nm_telefone,
                     cd_cep, nm_rua, nm_bairro, nm_cidade, sg_estado, ic_tipo)
                VALUES
                    (@nm_usuario, @nm_email, @ds_senha_hash, @nm_telefone,
                     @cd_cep, @nm_rua, @nm_bairro, @nm_cidade, @sg_estado, @ic_tipo)";

            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@nm_usuario", u.NmUsuario);
                cmd.Parameters.AddWithValue("@nm_email", u.NmEmail);
                cmd.Parameters.AddWithValue("@ds_senha_hash", u.DsSenhaHash);
                cmd.Parameters.AddWithValue("@nm_telefone", u.NmTelefone);
                cmd.Parameters.AddWithValue("@cd_cep", u.CdCep);
                cmd.Parameters.AddWithValue("@nm_rua", u.NmRua);
                cmd.Parameters.AddWithValue("@nm_bairro", u.NmBairro);
                cmd.Parameters.AddWithValue("@nm_cidade", u.NmCidade);
                cmd.Parameters.AddWithValue("@sg_estado", u.SgEstado);
                cmd.Parameters.AddWithValue("@ic_tipo", "USER");
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Busca um usuário pelo e-mail e hash da senha.
        /// Decisão: Consulta utilizada para autenticação, nunca trazendo a senha original do banco.
        /// </summary>
        /// <param name="email">E-mail do usuário.</param>
        /// <param name="senhaHash">Hash SHA256 da senha.</param>
        /// <returns>Usuário encontrado ou null se não existir.</returns>
        public Usuario BuscarPorLogin(string email, string senhaHash)
        {
            string sql = @"
                SELECT cd_usuario, nm_usuario, nm_email, nm_telefone, ic_tipo
                FROM   Usuario
                WHERE  nm_email = @nm_email AND ds_senha_hash = @ds_senha_hash";

            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@nm_email", email);
                cmd.Parameters.AddWithValue("@ds_senha_hash", senhaHash);

                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                        return new Usuario
                        {
                            CdUsuario = (int)r["cd_usuario"],
                            NmUsuario = (string)r["nm_usuario"],
                            NmEmail = (string)r["nm_email"],
                            NmTelefone = (string)r["nm_telefone"],
                            IcTipo = (string)r["ic_tipo"]
                        };
                    return null;
                }
            }
        }

        /// <summary>
        /// Atualiza os dados de um usuário existente.
        /// Decisão: Atualiza todos os campos relevantes, exceto a senha, para manter integridade cadastral.
        /// </summary>
        /// <param name="u">Usuário com dados atualizados.</param>
        public void Alterar(Usuario u)
        {
            string sql = @"UPDATE Usuario SET 
                    nm_usuario = @nm_usuario, 
                    nm_email = @nm_email, 
                    nm_telefone = @nm_telefone, 
                    cd_cep = @cd_cep, 
                    nm_rua = @nm_rua, 
                    nm_bairro = @nm_bairro, 
                    nm_cidade = @nm_cidade, 
                    sg_estado = @sg_estado, 
                    ic_tipo = @ic_tipo 
                  WHERE cd_usuario = @cd_usuario";

            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@cd_usuario", u.CdUsuario);
                cmd.Parameters.AddWithValue("@nm_usuario", u.NmUsuario);
                cmd.Parameters.AddWithValue("@nm_email", u.NmEmail);
                cmd.Parameters.AddWithValue("@nm_telefone", u.NmTelefone);
                cmd.Parameters.AddWithValue("@cd_cep", u.CdCep);
                cmd.Parameters.AddWithValue("@nm_rua", u.NmRua);
                cmd.Parameters.AddWithValue("@nm_bairro", u.NmBairro);
                cmd.Parameters.AddWithValue("@nm_cidade", u.NmCidade);
                cmd.Parameters.AddWithValue("@sg_estado", u.SgEstado);
                cmd.Parameters.AddWithValue("@ic_tipo", u.IcTipo);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Exclui um usuário do banco de dados.
        /// Decisão: Exclusão física, utilizada apenas em cenários administrativos.
        /// </summary>
        /// <param name="cdUsuario">Código do usuário a ser excluído.</param>
        public void Excluir(int cdUsuario)
        {
            string sql = "DELETE FROM Usuario WHERE cd_usuario = @cd_usuario";
            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@cd_usuario", cdUsuario);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
