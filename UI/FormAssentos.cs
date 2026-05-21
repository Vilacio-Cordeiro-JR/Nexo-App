using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Nexo_App.BLL;
using Nexo_App.DAL;
using Nexo_App.Models;

namespace Nexo_App.UI
{
    public partial class FormAssentos : Form
    {
        public FormAssentos()
        {
            InitializeComponent();
        }

        private void FormAssentos_Load(object sender, EventArgs e)
        {
            // Garante que o painel não vai criar barras de rolagem e vai travar o tamanho fixo
            panelAssentos.AutoScroll = false;

            // Limpa seleções antigas antes de iniciar
            Sessao.AssentosSelecionados.Clear();

            if (Sessao.ViagemSelecionada != null)
                lblViagem.Text = Sessao.ViagemSelecionada.NmOrigem + " → " + Sessao.ViagemSelecionada.NmDestino;

            CarregarAssentos();
        }

        private void CarregarAssentos()
        {
            panelAssentos.Controls.Clear();

            try
            {
                var dal = new ViagemAssentoDAL.AssentoDAL();
                var assentos = dal.ListarPorViagem(Sessao.ViagemSelecionada.CdViagem);

                if (assentos == null || assentos.Count == 0) return;

                // --- CONFIGURAÇÃO DO LAYOUT HORIZONTAL ---
                int fileirasVerticais = 4;
                int totalAssentos = assentos.Count;
                int colunasProfundidade = (int)Math.Ceiling((double)totalAssentos / fileirasVerticais);

                int padding = 15;
                int espacamento = 5;
                int corredorCentral = 26;

                // Multiplicador de desalinhamento sutil solicitado (0.3 do tamanho do quadrado)
                float fatorDesalinhamento = 0.3f;
                int espacoCabineBase = 50;

                // --- CÁLCULO DO TAMANHO DINÂMICO DOS QUADRADOS ---
                int larguraDisponivel = panelAssentos.Width - (padding * 2) - espacoCabineBase - ((colunasProfundidade - 1) * espacamento);
                int tamanhoQuadradoX = larguraDisponivel / colunasProfundidade;

                int alturaDisponivel = panelAssentos.Height - (padding * 2) - ((fileirasVerticais - 1) * espacamento) - corredorCentral;
                int tamanhoQuadradoY = alturaDisponivel / fileirasVerticais;

                int tamanhoQuadrado = Math.Min(tamanhoQuadradoX, tamanhoQuadradoY);

                if (tamanhoQuadrado > 50) tamanhoQuadrado = 50;
                if (tamanhoQuadrado < 25) tamanhoQuadrado = 25;

                // Valor exato do recuo sutil (30% do tamanho do quadrado)
                int desalinhamentoPassageiro = (int)(tamanhoQuadrado * fatorDesalinhamento);

                // --- CENTRALIZAÇÃO VERTICAL ---
                int alturaTotalOnibus = (fileirasVerticais * tamanhoQuadrado) + ((fileirasVerticais - 1) * espacamento) + corredorCentral;
                int margemSuperior = (panelAssentos.Height - alturaTotalOnibus) / 2;
                int margemEsquerda = padding;

                // --- POSICIONAMENTO DO MOTORISTA (Ocupa a altura das duas fileiras de baixo) ---
                Label lblMotorista = new Label();
                lblMotorista.Text = "Driver";
                lblMotorista.Font = new Font("Arial", tamanhoQuadrado * 0.18F, FontStyle.Bold);
                lblMotorista.ForeColor = Color.DarkGray;
                lblMotorista.BackColor = Color.FromArgb(230, 230, 230);
                lblMotorista.TextAlign = ContentAlignment.MiddleCenter;

                // Define o tamanho para cobrir exatamente as duas linhas inferiores do layout
                int alturaDriver = (tamanhoQuadrado * 2) + espacamento;
                lblMotorista.Size = new Size((int)(tamanhoQuadrado * 0.9), alturaDriver);

                // Posiciona o Driver na metade inferior do ônibus (Linhas 2 e 3)
                int posYMotorista = margemSuperior + (2 * (tamanhoQuadrado + espacamento)) + corredorCentral;
                lblMotorista.Location = new Point(margemEsquerda, posYMotorista);
                panelAssentos.Controls.Add(lblMotorista);

                // Onde os assentos começam no eixo X (logo após o bloco do Driver)
                int inicioPassageirosX = margemEsquerda + lblMotorista.Width + 10;

                foreach (var assento in assentos)
                {
                    int i = assento.QtNumero;
                    var btn = new Button();

                    btn.Text = i.ToString("D2");
                    btn.Width = tamanhoQuadrado;
                    btn.Height = tamanhoQuadrado;
                    btn.Tag = assento;
                    btn.Cursor = Cursors.Hand;

                    // Estilo Clean Flat
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.Font = new Font("Segoe UI", tamanhoQuadrado * 0.22F, FontStyle.Bold);

                    // --- ORGANIZAÇÃO DA MATRIZ DO ÔNIBUS (Igual ao Mockup) ---
                    int nColunaX = (i - 1) / fileirasVerticais;
                    int resto = (i - 1) % fileirasVerticais;

                    // Mapeia para que fique: 
                    // Linha 0 (Topo): Janela de cima (resto == 3)
                    // Linha 1:        Corredor de cima (resto == 2)
                    // === CORREDOR ===
                    // Linha 2:        Corredor de baixo (resto == 1) -> Começa com 02
                    // Linha 3 (Base): Janela de baixo (resto == 0)    -> Começa com 01
                    int nLinhaY = 0;
                    if (resto == 0) nLinhaY = 3;
                    else if (resto == 1) nLinhaY = 2;
                    else if (resto == 2) nLinhaY = 1;
                    else if (resto == 3) nLinhaY = 0;

                    // --- RECUO ESTILO MOCKUP ---
                    // As duas fileiras de CIMA (linhas 0 e 1) recuam sutilmente para a direita
                    int recuoX = 0;
                    if (nLinhaY <= 1)
                    {
                        recuoX = desalinhamentoPassageiro;
                    }

                    int offsetY = (nLinhaY >= 2) ? corredorCentral : 0;

                    // Define a posição final na tela
                    btn.Left = inicioPassageirosX + (nColunaX * (tamanhoQuadrado + espacamento)) + recuoX;
                    btn.Top = margemSuperior + (nLinhaY * (tamanhoQuadrado + espacamento)) + offsetY;

                    // --- LOGICA DE CORES MANTIDA ---
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

        // Pequena variável auxiliar apenas para a matemática do tamanho do frame anterior
        private int tamanhoQuadradoEspera = 45;

        private void Assento_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var assento = (Assento)btn.Tag;

            if (Sessao.AssentosSelecionados.Contains(assento))
            {
                Sessao.AssentosSelecionados.Remove(assento);

                // Volta para o estado Livre (Fundo Branco, Borda e Texto Verdes)
                btn.BackColor = Color.White;
                btn.FlatAppearance.BorderColor = Color.FromArgb(76, 175, 80);
                btn.ForeColor = Color.FromArgb(76, 175, 80);
            }
            else
            {
                Sessao.AssentosSelecionados.Add(assento);

                // Estado Selecionado: Amarelo preenchido com texto branco (Legível e elegante)
                btn.BackColor = Color.FromArgb(255, 193, 7); // Amarelo Vivo
                btn.FlatAppearance.BorderColor = Color.FromArgb(230, 162, 2);
                btn.ForeColor = Color.White;
            }

            AtualizarLabel();
        }

        private void AtualizarLabel()
        {
            if (Sessao.AssentosSelecionados.Count == 0)
            {
                lblSelecionados.Text = "Assentos selecionados: nenhum";
                return;
            }

            // Cria uma lista de inteiros para ordenar os números numericamente antes de exibir
            var nums = new List<int>();
            foreach (var a in Sessao.AssentosSelecionados)
            {
                nums.Add(a.QtNumero);
            }

            nums.Sort(); // Ordena: deixa em ordem crescente (ex: 6, 37, 38...)

            lblSelecionados.Text = "Assentos selecionados: " + string.Join(", ", nums);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Sessao.AssentosSelecionados.Count == 0)
            {
                MessageBox.Show("Selecione pelo menos um assento para prosseguir!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frmConfirmacao = new FormConfirmacao();
            frmConfirmacao.Show();

            this.Dispose(); // Fecha e libera a memória desta tela atual de forma correta
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var frmHome = new FormHome();
            frmHome.Show();
            this.Dispose();
        }
    }
}