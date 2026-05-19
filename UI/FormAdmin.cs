using System;
using System.Windows.Forms;
using Nexo_App.BLL;

namespace Nexo_App.UI
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void btnCriarViagem_Click(object sender, EventArgs e)
        {
            try
            {
                var bll = new ViagemBLL();
                bll.CriarViagem(
                    txtOrigem.Text,
                    txtDestino.Text,
                    dateTimePicker1.Value,
                    txtPreco.Text,
                    txtAssentos.Text
                );

                lblErroAdmin.Visible = false;
                MessageBox.Show("Viagem criada com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtOrigem.Clear();
                txtDestino.Clear();
                txtPreco.Clear();
                txtAssentos.Text = "40";
            }
            catch (Exception ex)
            {
                lblErroAdmin.Text    = ex.Message;
                lblErroAdmin.Visible = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReservas.Rows.Clear();
                var bll      = new ReservaBLL();
                var reservas = bll.ListarTodas();

                foreach (var r in reservas)
                    dgvReservas.Rows.Add(
                        r.CdReserva,
                        r.NmUsuario,
                        r.NmOrigem,
                        r.NmDestino,
                        r.DtReserva.ToString("dd/MM/yyyy HH:mm"),
                        r.Assentos
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar reservas: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Sessao.UsuarioLogado = null;
            new FormLogin().Show();
            this.Close();
        }
    }
}
