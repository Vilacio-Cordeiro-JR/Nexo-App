using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Nexo_App.BLL;

namespace Nexo_App.UI
{
    /// <summary>
    /// Formulário de autenticação principal do sistema.
    /// Gerencia o acesso de usuários comuns, administradores e redirecionamentos.
    /// </summary>
    public partial class FormLogin : Form
    {
        /// <summary>
        /// Construtor do formulário. Inicializa os componentes e define os estilos padrão dos botões.
        /// </summary>
        public FormLogin()
        {
            InitializeComponent();

            // CORREÇÃO: A linha "this.FormClosed += ..." foi removida daqui. 
            // Agora o formulário pode se fechar livremente para passar o controle ao Program.cs.

            // Configuração de estilo flat para o botão de cadastro
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.FlatAppearance.BorderSize = 0;
            btnCadastrar.UseVisualStyleBackColor = false;
        }

        /// <summary>
        /// Evento executado no carregamento do formulário. Aplica o visual arredondado aos botões.
        /// </summary>
        private void FormLogin_Load(object sender, EventArgs e)
        {
            AplicarBordaArredondada(btnEntrar, 30);
            AplicarBordaArredondada(btnCadastrar, 30);
            AplicarBordaArredondada(btnAcessoAdmin, 30);
        }

        /// <summary>
        /// Processa a tentativa de login comum autenticando o usuário e direcionando com base em seu perfil.
        /// </summary>
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roundedTextBox2.Text) || string.IsNullOrWhiteSpace(roundedTextBox1.Text))
                {
                    throw new Exception("Por favor, preencha o e-mail e a senha para continuar.");
                }

                var bll = new UsuarioBLL();
                var usuario = bll.Login(roundedTextBox2.Text, roundedTextBox1.Text);

                // Define globalmente o usuário ativo
                Sessao.UsuarioLogado = usuario;

                // Transiciona o controle fechando o login
                this.Close();
            }
            catch (Exception ex)
            {
                lblErro.Text = ex.Message;
                lblErro.Visible = true;
            }
        }

        /// <summary>
        /// Abre a tela de cadastro de novos usuários de forma modal.
        /// </summary>
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var cadastro = new FormCadastro();
            this.Hide();

            cadastro.ShowDialog(); // Abre em modo de diálogo bloqueante (por cima)

            this.Show(); // Retorna a visibilidade deste login assim que a tela de cadastro for fechada
        }

        /// <summary>
        /// Abre a tela secundária de autenticação restrita para administradores.
        /// </summary>
        private void btnAcessoAdmin_Click(object sender, EventArgs e)
        {
            using (var loginAdmin = new FormLoginAdmin())
            {
                this.Hide(); // Esconde temporariamente para dar foco ao sub-login modal
                loginAdmin.ShowDialog();

                // Se o sub-login guardou um usuário na sessão, fecha este FormLogin também!
                if (Sessao.UsuarioLogado != null)
                {
                    this.Close(); // Fecha o login comum para o Program.cs assumir o controle
                }
                else
                {
                    this.Show(); // Se cancelou o sub-login, mostra o login comum de volta
                }
            }
        }

        /// <summary>
        /// Altera a região geométrica do botão para simular um acabamento arredondado moderno.
        /// </summary>
        private void AplicarBordaArredondada(Button btn, int raio)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, raio, raio, 180, 90);
                path.AddArc(btn.Width - raio, 0, raio, raio, 270, 90);
                path.AddArc(btn.Width - raio, btn.Height - raio, raio, raio, 0, 90);
                path.AddArc(0, btn.Height - raio, raio, raio, 90, 90);
                path.CloseAllFigures();

                btn.Region = new Region(path);
            }
        }
    }
}