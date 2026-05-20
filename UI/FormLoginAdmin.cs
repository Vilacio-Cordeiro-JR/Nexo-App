using Nexo_App.BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nexo_App.UI
{
    public partial class FormLoginAdmin : Form
    {
        public FormLoginAdmin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                var bll = new UsuarioBLL();
                var usuario = bll.Login(txtEmail.Text, txtSenha.Text);

                if (usuario.IcTipo != "ADMIN")
                    throw new Exception("Acesso negado. Usuário não é administrador.");

                Sessao.UsuarioLogado = usuario;

                var admin = new FormAdmin();
                admin.FormClosed += (s, ev) => Application.Exit();
                admin.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                lblErro.Text = ex.Message;
                lblErro.Visible = true;
            }
        }

        

  // ← fechamento da classe

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close(); // Apenas fecha esta janela; o FormLogin original reaparecerá sozinho
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

        

        private void FormLoginAdmin_Load_1(object sender, EventArgs e)
        {
            AplicarBordaArredondada(btnEntrar, 30);
            AplicarBordaArredondada(btnVoltar, 30);
        }
    }
}
