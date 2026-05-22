using Nexo_App.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Nexo_App.UI
{
    /// <summary>
    /// Formulário de fechamento de pedido e resumo de transação.
    /// Consolida as informações da viagem selecionada, os assentos reservados e realiza 
    /// a computação dos valores financeiros antes da persistência final da reserva.
    /// </summary>
    public partial class FormConfirmacao : Form
    {
        public FormConfirmacao()
        {
            InitializeComponent();

            // Padronização visual da identidade do software aplicando cantos arredondados nos containers e botões
            AplicarBordaArredondada(panelResumo, 15);
            AplicarBordaArredondada(panel1, 15);
            AplicarBordaArredondada(panel2, 15);
            AplicarBordaArredondada(btnConfirmar, 15);
            AplicarBordaArredondada(btnVoltar, 15);
        }

        /// <summary>
        /// Executa procedimentos de validação de estado e preenchimento de metadados 
        /// financeiros e textuais assim que a janela é carregada em memória.
        /// </summary>
        private void FormConfirmacao_Load(object sender, EventArgs e)
        {
            // VALIDAÇÃO DEFENSIVA DE SESSÃO
            if (Sessao.ViagemSelecionada == null || Sessao.AssentosSelecionados == null)
            {
                MessageBox.Show("Dados da sessão não encontrados. Você será redirecionado.",
                                "Erro de Sessão", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.DialogResult = DialogResult.Abort; // Sinaliza que o fluxo quebrou por falta de dados
                this.Close();
                return;
            }

            // 1. Vinculação dos dados descritivos da viagem ativa
            lblOrigem.Text = Sessao.ViagemSelecionada.NmOrigem;
            lblDestino.Text = Sessao.ViagemSelecionada.NmDestino;
            lblData.Text = Sessao.ViagemSelecionada.DtViagem.ToString("dd/MM/yyyy HH:mm");

            // 2. Mapeamento e agregação dos assentos escolhidos
            if (Sessao.AssentosSelecionados.Count == 0)
            {
                lblAssentos.Text = "Nenhum assento selecionado";
                lblTotal.Text = "R$ 0,00";
                btnConfirmar.Enabled = false; // Trava de segurança contra requisições vazias
                return;
            }

            var nums = new List<string>();
            foreach (var a in Sessao.AssentosSelecionados)
            {
                nums.Add(a.QtNumero.ToString());
            }
            lblAssentos.Text = string.Join(", ", nums);

            // CÁLCULO FINANCEIRO DINÂMICO
            decimal total = Sessao.ViagemSelecionada.VlPreco * Sessao.AssentosSelecionados.Count;
            lblTotal.Text = total.ToString("C2");
        }

        /// <summary>
        /// Processa a confirmação final da reserva do bilhete, enviando as referências do usuário,
        /// da viagem e das poltronas para a camada de persistência.
        /// </summary>
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

                // ARQUITETURA CENTRALIZADA: Sinaliza sucesso e fecha. 
                // As telas anteriores saberão que a compra foi concluída e limparão o cache de forma ordenada.
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao confirmar reserva: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Interrompe o fluxo de confirmação e retorna o usuário ao mapa de assentos, preservando o estado das escolhas.
        /// </summary>
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            // ARQUITETURA CENTRALIZADA: Define Cancel e fecha. O FormAssentos vai reaparecer sozinho.
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Modifica a geometria de renderização nativa de um controle do Windows Forms.
        /// </summary>
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