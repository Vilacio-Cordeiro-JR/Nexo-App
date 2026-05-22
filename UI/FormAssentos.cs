using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Nexo_App.BLL;
using Nexo_App.DAL;
using Nexo_App.Models;

namespace Nexo_App.UI
{
    /// <summary>
    /// Formulário interativo para seleção e exibição do mapa de assentos do ônibus.
    /// Renderiza dinamicamente a disposição física do veículo e gerencia a seleção de poltronas.
    /// </summary>
    public partial class FormAssentos : Form
    {
        private int tamanhoQuadradoEspera = 45;

        public FormAssentos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Configura as propriedades visuais do container e inicializa o estado dos dados ao carregar a tela.
        /// </summary>
        private void FormAssentos_Load(object sender, EventArgs e)
        {
            panelAssentos.AutoScroll = false;
            panelAssentos.BackColor = Color.FromArgb(80, 0, 120, 215);

            // Garante que não haja resíduos de escolhas anteriores ao abrir a tela
            Sessao.AssentosSelecionados.Clear();

            if (Sessao.ViagemSelecionada != null)
                lblViagem.Text = Sessao.ViagemSelecionada.NmOrigem + " → " + Sessao.ViagemSelecionada.NmDestino;

            CarregarAssentos();
        }

        /// <summary>
        /// Processa a leitura dos dados do banco e renderiza dinamicamente o mapa físico do ônibus.
        /// </summary>
        private void CarregarAssentos()
        {
            panelAssentos.Controls.Clear();

            try
            {
                var dal = new ViagemAssentoDAL.AssentoDAL();
                var assentos = dal.ListarPorViagem(Sessao.ViagemSelecionada.CdViagem);

                if (assentos == null || assentos.Count == 0) return;

                int fileirasVerticais = 4;
                int totalAssentos = assentos.Count;
                int colunasProfundidade = (int)Math.Ceiling((double)totalAssentos / fileirasVerticais);

                int padding = 15;
                int espacamento = 5;
                int corridorCentral = 26;

                float fatorDesalinhamento = 0.3f;
                int espacoCabineBase = 50;

                int larguraDisponivel = panelAssentos.Width - (padding * 2) - espacoCabineBase - ((colunasProfundidade - 1) * espacamento);
                int tamanhoQuadradoX = larguraDisponivel / colunasProfundidade;

                int alturaDisponivel = panelAssentos.Height - (padding * 2) - ((fileirasVerticais - 1) * espacamento) - corridorCentral;
                int tamanhoQuadradoY = alturaDisponivel / fileirasVerticais;

                int tamanhoQuadrado = Math.Min(tamanhoQuadradoX, tamanhoQuadradoY);

                if (tamanhoQuadrado > 50) tamanhoQuadrado = 50;
                if (tamanhoQuadrado < 25) tamanhoQuadrado = 25;

                int desalinhamentoPassageiro = (int)(tamanhoQuadrado * fatorDesalinhamento);
                int alturaTotalOnibus = (fileirasVerticais * tamanhoQuadrado) + ((fileirasVerticais - 1) * espacamento) + corridorCentral;
                int margemSuperior = (panelAssentos.Height - alturaTotalOnibus) / 2;
                int margemEsquerda = padding;

                // MOTORISTA
                Label lblMotorista = new Label();
                lblMotorista.Text = "Driver";
                lblMotorista.Font = new Font("Arial", tamanhoQuadrado * 0.18F, FontStyle.Bold);
                lblMotorista.ForeColor = Color.DarkGray;
                lblMotorista.BackColor = Color.FromArgb(230, 230, 230);
                lblMotorista.TextAlign = ContentAlignment.MiddleCenter;

                int alturaDriver = (tamanhoQuadrado * 2) + espacamento;
                lblMotorista.Size = new Size((int)(tamanhoQuadrado * 0.9), alturaDriver);

                int posYMotorista = margemSuperior + (2 * (tamanhoQuadrado + espacamento)) + corridorCentral;
                lblMotorista.Location = new Point(margemEsquerda, posYMotorista);
                panelAssentos.Controls.Add(lblMotorista);

                int inicioPassageirosX = margemEsquerda + lblMotorista.Width + 10;

                // PASSAGEIROS
                foreach (var assento in assentos)
                {
                    int i = assento.QtNumero;
                    var btn = new Button();

                    btn.Text = i.ToString("D2");
                    btn.Size = new Size(tamanhoQuadrado, tamanhoQuadrado);
                    btn.Tag = assento;
                    btn.Cursor = Cursors.Hand;

                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.Font = new Font("Segoe UI", tamanhoQuadrado * 0.22F, FontStyle.Bold);

                    int nColunaX = (i - 1) / fileirasVerticais;
                    int resto = (i - 1) % fileirasVerticais;

                    int nLinhaY = 0;
                    if (resto == 0) nLinhaY = 3;
                    else if (resto == 1) nLinhaY = 2;
                    else if (resto == 2) nLinhaY = 1;
                    else if (resto == 3) nLinhaY = 0;

                    int recuoX = 0;
                    if (nLinhaY <= 1) recuoX = desalinhamentoPassageiro;

                    int offsetY = (nLinhaY >= 2) ? corridorCentral : 0;

                    btn.Left = inicioPassageirosX + (nColunaX * (tamanhoQuadrado + espacamento)) + recuoX;
                    btn.Top = margemSuperior + (nLinhaY * (tamanhoQuadrado + espacamento)) + offsetY;

                    // ESTADOS VISUAIS
                    if (assento.IcStatus == "OCUPADO")
                    {
                        btn.BackColor = Color.FromArgb(244, 67, 54);
                        btn.FlatAppearance.BorderColor = Color.FromArgb(198, 40, 40);
                        btn.ForeColor = Color.White;
                        btn.Text = "X";
                        btn.Enabled = false;
                    }
                    else
                    {
                        if (Sessao.AssentosSelecionados.Contains(assento))
                        {
                            btn.BackColor = Color.FromArgb(255, 193, 7);
                            btn.FlatAppearance.BorderColor = Color.FromArgb(230, 162, 2);
                            btn.ForeColor = Color.White;
                        }
                        else
                        {
                            btn.BackColor = Color.White;
                            btn.FlatAppearance.BorderColor = Color.FromArgb(76, 175, 80);
                            btn.ForeColor = Color.FromArgb(76, 175, 80);
                        }

                        btn.Click += Assento_Click;
                    }

                    panelAssentos.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao renderizar layout do mockup: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Assento_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var assento = (Assento)btn.Tag;

            if (Sessao.AssentosSelecionados.Contains(assento))
            {
                Sessao.AssentosSelecionados.Remove(assento);
                btn.BackColor = Color.White;
                btn.FlatAppearance.BorderColor = Color.FromArgb(76, 175, 80);
                btn.ForeColor = Color.FromArgb(76, 175, 80);
            }
            else
            {
                Sessao.AssentosSelecionados.Add(assento);
                btn.BackColor = Color.FromArgb(255, 193, 7);
                btn.FlatAppearance.BorderColor = Color.FromArgb(230, 162, 2);
                btn.ForeColor = Color.White;
            }

            AtualizarLabel();
        }

        private void AktualizarLabel() // Mantendo compatibilidade com seu método
        {
            AtualizarLabel();
        }

        private void AtualizarLabel()
        {
            if (Sessao.AssentosSelecionados.Count == 0)
            {
                lblSelecionados.Text = "Assentos selecionados: nenhum";
                return;
            }

            var nums = new List<int>();
            foreach (var a in Sessao.AssentosSelecionados)
            {
                nums.Add(a.QtNumero);
            }

            nums.Sort();
            lblSelecionados.Text = "Assentos selecionados: " + string.Join(", ", nums);
        }

        /// <summary>
        /// CORRIGIDO: Avança para a tela de confirmação de forma controlada (Modal).
        /// </summary>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Sessao.AssentosSelecionados.Count == 0)
            {
                MessageBox.Show("Selecione pelo menos um assento para prosseguir!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Abre a confirmação em modo de diálogo
            using (var frmConfirmacao = new FormConfirmacao())
            {
                this.Hide(); // Esconde o mapa de assentos temporariamente

                DialogResult resultado = frmConfirmacao.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    // Compra realizada com sucesso! Define o resultado desta tela como OK 
                    // e fecha para retornar direto ao FormHome original.
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (resultado == DialogResult.Abort)
                {
                    // Erro crítico de sessão
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
                else
                {
                    // Se o usuário clicou em "Voltar" na confirmação, reexibe a tela de assentos intacta
                    this.Show();
                }
            }
        }

        /// <summary>
        /// CORRIGIDO: Fecha a tela atual de forma limpa retornando o controle para a Home original.
        /// </summary>
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            // Apenas fecha esta janela. Como o FormHome a chamou com ShowDialog(), 
            // a Home original voltará a ficar visível instantaneamente.
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}