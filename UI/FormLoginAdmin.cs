using System;
using System.Windows.Forms;
using Nexo_App.BLL;

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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close(); // Apenas fecha esta janela; o FormLogin original reaparecerá sozinho
        }
    }
}
