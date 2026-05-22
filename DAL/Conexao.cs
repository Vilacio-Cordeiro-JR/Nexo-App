using System.Data.SqlClient;

namespace Nexo_App.DAL
{
    /// <summary>
    /// Gerenciador de conexão com o banco de dados SQL Server.
    /// Centraliza a string de conexão e automatiza o processo de abertura para reutilização nas classes DAL.
    /// </summary>
    public class Conexao
    {
        /// <summary>
        /// String de conexão configurada para utilizar um banco de dados local embutido (LocalDB).
        /// Decisões de parâmetros:
        /// - AttachDbFilename: Acopla dinamicamente o arquivo .mdf localizado na pasta App_Data/bin do projeto.
        /// - Integrated Security: Utiliza a autenticação do Windows (segurança integrada).
        /// - TrustServerCertificate: Evita falhas de handshake SSL em ambientes de desenvolvimento local.
        /// </summary>
        private const string STRING_CONEXAO = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SistemaPassagens.mdf;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True;";

        /// <summary>
        /// Cria, inicializa e abre uma nova instância de conexão com o banco de dados.
        /// </summary>
        /// <remarks>
        /// Importante: A conexão retornada por este método deve ser obrigatoriamente descartada 
        /// pelo chamador através de um bloco 'using' para evitar vazamento de conexões no pool (Connection Pool).
        /// </remarks>
        /// <returns>Uma instância aberta de <see cref="SqlConnection"/> pronta para executar comandos.</returns>
        public static SqlConnection Abrir()
        {
            var con = new SqlConnection(STRING_CONEXAO);
            con.Open();
            return con;
        }
    }
}