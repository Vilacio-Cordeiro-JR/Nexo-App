using System.Collections.Generic;
using System.Data.SqlClient;
using Nexo_App.Models;

namespace Nexo_App.DAL
{
    public class UsuarioDAL
    {
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
                cmd.Parameters.AddWithValue("@nm_usuario",    u.NmUsuario);
                cmd.Parameters.AddWithValue("@nm_email",      u.NmEmail);
                cmd.Parameters.AddWithValue("@ds_senha_hash", u.DsSenhaHash);
                cmd.Parameters.AddWithValue("@nm_telefone",   u.NmTelefone);
                cmd.Parameters.AddWithValue("@cd_cep",        u.CdCep);
                cmd.Parameters.AddWithValue("@nm_rua",        u.NmRua);
                cmd.Parameters.AddWithValue("@nm_bairro",     u.NmBairro);
                cmd.Parameters.AddWithValue("@nm_cidade",     u.NmCidade);
                cmd.Parameters.AddWithValue("@sg_estado",     u.SgEstado);
                cmd.Parameters.AddWithValue("@ic_tipo",       "USER");
                cmd.ExecuteNonQuery();
            }
        }

        public Usuario BuscarPorLogin(string email, string senhaHash)
        {
            string sql = @"
                SELECT cd_usuario, nm_usuario, nm_email, nm_telefone, ic_tipo
                FROM   Usuario
                WHERE  nm_email = @nm_email AND ds_senha_hash = @ds_senha_hash";

            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@nm_email",      email);
                cmd.Parameters.AddWithValue("@ds_senha_hash", senhaHash);

                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                        return new Usuario
                        {
                            CdUsuario  = (int)    r["cd_usuario"],
                            NmUsuario  = (string) r["nm_usuario"],
                            NmEmail    = (string) r["nm_email"],
                            NmTelefone = (string) r["nm_telefone"],
                            IcTipo     = (string) r["ic_tipo"]
                        };
                    return null;
                }
            }
        }
    }
}
