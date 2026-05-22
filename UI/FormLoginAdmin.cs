using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Nexo_App.BLL;
using Nexo_App.Models;

namespace Nexo_App.UI
{
    /// <summary>
    /// Formulário de autenticação restrito para usuários com privilégios administrativos (ADMIN).
    /// </summary>
    public partial class FormLoginAdmin : Form
    {
        /// <summary>
        /// Construtor do formulário. Inicializa os componentes do designer.
        /// </summary>
        public FormLoginAdmin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento de inicialização do formulário. Aplica as customizações visuais de UI.
        /// </summary>
        private void FormLoginAdmin_Load_1(object sender, EventArgs e)
        {
            // Aplica a estética moderna de cantos arredondados nos botões de ação
            AplicarBordaArredondada(btnEntrar, 30);
            AplicarBordaArredondada(btnVoltar, 30);
        }

        /// <summary>
        /// Processa a tentativa de login administrativo autenticando as credenciais na BLL.
        /// </summary>
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDAÇÃO EM CAMADA DE INTERFACE (UX): Impede chamadas desnecessárias ao banco de dados
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    throw new Exception("Por favor, preencha todos os campos de credenciais.");
                }

                var bll = new UsuarioBLL();
                var usuario = bll.Login(txtEmail.Text, txtSenha.Text);

                // REGRA DE ACESSO: Valida se o perfil retornado possui o nível de direito necessário
                if (usuario.IcTipo != "ADMIN")
                {
                    throw new Exception("Acesso negado. Usuário não possui privilégios de administrador.");
                }

                // ONDE ADICIONAR: Armazena o usuário autenticado no contexto global de Sessão.
                // Agora, em vez de abrir telas por aqui, nós apenas fechamos o formulário.
                Sessao.UsuarioLogado = usuario;

                // FLUXO CENTRALIZADO: Fecha esta janela de sub-login indicando sucesso.
                // O FormLogin e o Program.cs vão ler o estado da Sessão e abrir o FormAdmin de forma limpa.
                this.Close();
            }
            catch (Exception ex)
            {
                // Exibe mensagens de erro amigáveis ou rejeições diretamente na label de feedback
                lblErro.Text = ex.Message;
                lblErro.Visible = true;
            }
        }

        /// <summary>
        /// Encerra a tela de login administrativo, devolvendo o controle à janela chamadora.
        /// </summary>
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close(); // Apenas fecha esta janela; o FormLogin original reaparecerá sozinho
        }

        /// <summary>
        /// Altera a região geométrica do botão para simular um acabamento arredondado moderno.
        /// </summary>
        /// <param name="btn">O controle do tipo Button que receberá a estilização.</param>
        /// <param name="raio">O raio de curvatura dos cantos em pixels.</param>
        private void AplicarBordaArredondada(Button btn, int raio)
        {
            // GERENCIAMENTO DE RECURSOS GDI+: O uso do 'using' garante o descarte do path
            // e previne o vazamento de memória gráfica/GDI handles no Windows.
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, raio, raio, 180, 90);
                path.AddArc(btn.Width - raio, 0, raio, raio, 270, 90);
                path.AddArc(btn.Width - raio, btn.Height - raio, raio, raio, 0, 90);
                path.AddArc(0, btn.Height - raio, raio, raio, 90, 90);
                path.CloseAllFigures();

                // Atribui a nova geometria de exibição ao botão
                btn.Region = new Region(path);
            }
        }
    }
}