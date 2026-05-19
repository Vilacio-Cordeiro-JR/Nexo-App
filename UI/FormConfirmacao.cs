using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Nexo_App.BLL;

namespace Nexo_App.UI
{
    public partial class FormConfirmacao : Form
    {
        public FormConfirmacao()
        {
            InitializeComponent();
        }

        private void FormConfirmacao_Load(object sender, EventArgs e)
        {
            // Preenche o resumo com os dados reais da sessão
            if (Sessao.ViagemSelecionada != null)
            {
                lblOrigem.Text  = Sessao.ViagemSelecionada.NmOrigem;
                lblDestino.Text = Sessao.ViagemSelecionada.NmDestino;
                lblData.Text    = Sessao.ViagemSelecionada.DtViagem.ToString("dd/MM/yyyy HH:mm");
            }

            var nums = new List<string>();
            foreach (var a in Sessao.AssentosSelecionados)
                nums.Add(a.QtNumero.ToString());

            lblAssentos.Text = string.Join(", ", nums);

            // Calcula o total
            decimal total = Sessao.ViagemSelecionada.VlPreco * Sessao.AssentosSelecionados.Count;
            lblTotal.Text = "R$ " + total.ToString("F2");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                var bll = new ReservaBLL();
                bll.ConfirmarReserva(
                    Sessao.UsuarioLogado.CdUsuario,
                    Sessao.ViagemSelecionada.CdViagem,
                    Sessao.AssentosSelecionados
                );

                MessageBox.Show("Reserva confirmada com sucesso!\nObrigado por escolher nosso sistema.",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpa seleção e volta pra home
                Sessao.AssentosSelecionados.Clear();
                Sessao.ViagemSelecionada = null;

                new FormHome().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao confirmar reserva: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new FormAssentos().Show();
            this.Close();
        }
    }
}
