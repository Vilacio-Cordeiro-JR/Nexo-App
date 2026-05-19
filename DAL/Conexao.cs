using System.Data.SqlClient;

namespace Nexo_App.DAL
{
    public class Conexao
    {
        // Troque "localhost\\SQLEXPRESS" pelo nome da sua instância
        private const string STRING_CONEXAO = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SistemaPassagens.mdf;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True;";
        public static SqlConnection Abrir()
        {
            var con = new SqlConnection(STRING_CONEXAO);
            con.Open();
            return con;
        }
    }
}
