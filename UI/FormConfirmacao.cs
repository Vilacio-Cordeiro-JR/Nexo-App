using Nexo_App.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Nexo_App.UI
{
    public partial class FormConfirmacao : Form
    {
        public FormConfirmacao()
        {
            InitializeComponent();
            AplicarBordaArredondada(panelResumo, 15);
            AplicarBordaArredondada(panel1, 15);
            AplicarBordaArredondada(panel2, 15);
            AplicarBordaArredondada(btnConfirmar, 15);
            AplicarBordaArredondada(btnVoltar, 15);
        }

        private void FormConfirmacao_Load(object sender, EventArgs e)
        {
            // Validação de segurança defensiva: evita que o app quebre se a sessão sumir
            if (Sessao.ViagemSelecionada == null || Sessao.AssentosSelecionados == null)
            {
                MessageBox.Show("Dados da sessão não encontrados. Você será redirecionado para a tela inicial.",
                                "Erro de Sessão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VoltarParaHome();
                return;
            }

            // 1. Preenche os dados textuais da viagem
            lblOrigem.Text = Sessao.ViagemSelecionada.NmOrigem;
            lblDestino.Text = Sessao.ViagemSelecionada.NmDestino;
            lblData.Text = Sessao.ViagemSelecionada.DtViagem.ToString("dd/MM/yyyy HH:mm");

            // 2. Mapeia e junta os assentos escolhidos dinamicamente
            if (Sessao.AssentosSelecionados.Count == 0)
            {
                lblAssentos.Text = "Nenhum assento selecionado";
                lblTotal.Text = "R$ 0,00";
                btnConfirmar.Enabled = false; // Bloqueia o botão se não houver o que pagar
                return;
            }

            var nums = new List<string>();
            foreach (var a in Sessao.AssentosSelecionados)
            {
                nums.Add(a.QtNumero.ToString());
            }
            lblAssentos.Text = string.Join(", ", nums);

            // 3. CALCULO DINÂMICO DO PREÇO
            decimal total = Sessao.ViagemSelecionada.VlPreco * Sessao.AssentosSelecionados.Count;

            // O formato "C2" coloca automaticamente o símbolo da moeda local (R$) e formata as casas decimais corretamente
            lblTotal.Text = total.ToString("C2");
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

                VoltarParaHome();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao confirmar reserva: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var formAssentos = new FormAssentos();
            formAssentos.Show();
            this.Dispose(); // Libera os recursos da tela atual da memória de forma limpa
        }

        private void VoltarParaHome()
        {
            // Limpa a seleção da sessão antes de sair
            if (Sessao.AssentosSelecionados != null) Sessao.AssentosSelecionados.Clear();
            Sessao.ViagemSelecionada = null;

            var formHome = new FormHome();
            formHome.Show();
            this.Dispose();
        }

        private void AplicarBordaArredondada(Control ctrl, int raio)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(ctrl.Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(ctrl.Width - raio, ctrl.Height - raio, raio, raio, 0, 90);
            path.AddArc(0, ctrl.Height - raio, raio, raio, 90, 90);
            path.CloseAllFigures();
            ctrl.Region = new Region(path);
        }
    }
}