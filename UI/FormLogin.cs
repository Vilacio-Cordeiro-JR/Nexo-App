using Nexo_App.BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nexo_App.UI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            // Mata o processo do Windows se fechar no "X" antes de logar
            this.FormClosed += (s, e) => Application.Exit();

            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.FlatAppearance.BorderSize = 0;
            btnCadastrar.UseVisualStyleBackColor = false;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                var bll = new UsuarioBLL();
                var usuario = bll.Login(roundedTextBox2.Text, roundedTextBox1.Text);

                Sessao.UsuarioLogado = usuario;

                if (usuario.IcTipo == "ADMIN")
                {
                    var admin = new FormAdmin();
                    admin.FormClosed += (s, ev) => Application.Exit();
                    admin.Show();
                    this.Hide(); // Esconde o login apenas se o sucesso for confirmado
                }
                else
                {
                    var home = new FormHome();
                    home.FormClosed += (s, ev) => Application.Exit();
                    home.Show();
                    this.Hide(); // Esconde o login apenas se o sucesso for confirmado
                }
            }
            catch (Exception ex)
            {
                lblErro.Text = ex.Message;
                lblErro.Visible = true;
            }
        } 

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var cadastro = new FormCadastro();
            this.Hide();
            cadastro.ShowDialog(); // Abre por cima
            this.Show(); // Volta o login quando fechar o cadastro;
        }
        private void AplicarBordaArredondada(Button btn, int raio)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(btn.Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(btn.Width - raio, btn.Height - raio, raio, raio, 0, 90);
            path.AddArc(0, btn.Height - raio, raio, raio, 90, 90);
            path.CloseAllFigures();
            btn.Region = new Region(path);
        }

    



        private void btnAcessoAdmin_Click(object sender, EventArgs e)
        {
            var loginAdmin = new FormLoginAdmin();

            // 🔥 A MÁGICA: Se o LoginAdmin abrir com sucesso o painel de Admin, ele vai esconder essa tela.
            // Nós só queremos que o Login principal reapareça se o usuário CLICAR EM VOLTAR (fechar a tela de sub-login).
            this.Hide();

            loginAdmin.ShowDialog();

            // Se o usuário fechou a tela de sub-login sem logar (clicando em Voltar), e o Admin NÃO foi aberto:
            if (Sessao.UsuarioLogado == null)
            {
                this.Show(); // Mostra o login comum de volta
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            AplicarBordaArredondada(btnEntrar, 30);
            AplicarBordaArredondada(btnCadastrar, 30);
            AplicarBordaArredondada(btnAcessoAdmin, 30);
        }
    }
}
