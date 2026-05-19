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
        private List<Assento> _assentosForm = new List<Assento>();

        public FormAssentos()
        {
            InitializeComponent();
        }

        private void FormAssentos_Load(object sender, EventArgs e)
        {
            // Limpa seleções de acessos antigos antes de listar os novos
            Sessao.AssentosSelecionados.Clear();

            if (Sessao.ViagemSelecionada != null)
                lblViagem.Text = Sessao.ViagemSelecionada.NmOrigem + " → " + Sessao.ViagemSelecionada.NmDestino;

            CarregarAssentos();
        }

        private void CarregarAssentos()
        {
            panelAssentos.Controls.Clear();
            _assentosForm.Clear();

            try
            {
                var dal = new AssentoDAL();
                var assentos = dal.ListarPorViagem(Sessao.ViagemSelecionada.CdViagem);

                int largura = 60, altura = 60, espacamento = 10, colunas = 4;

                foreach (var assento in assentos)
                {
                    int i = assento.QtNumero;
                    var btn = new Button();
                    btn.Text      = i.ToString();
                    btn.Width     = largura;
                    btn.Height    = altura;
                    btn.Tag       = assento;       // guarda o objeto Assento no botão
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
                    btn.ForeColor = Color.White;

                    int linha  = (i - 1) / colunas;
                    int coluna = (i - 1) % colunas;
                    int offsetX = coluna >= 2
                        ? coluna * (largura + espacamento) + 25
                        : coluna * (largura + espacamento);

                    btn.Left = 20 + offsetX;
                    btn.Top  = 20 + linha * (altura + espacamento);

                    if (assento.IcStatus == "OCUPADO")
                    {
                        btn.BackColor = Color.FromArgb(244, 67, 54);
                        btn.Enabled   = false;
                    }
                    else
                    {
                        btn.BackColor = Color.FromArgb(76, 175, 80);
                        btn.Click    += Assento_Click;
                    }

                    panelAssentos.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar assentos: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Assento_Click(object sender, EventArgs e)
        {
            var btn     = (Button)sender;
            var assento = (Assento)btn.Tag;

            if (Sessao.AssentosSelecionados.Contains(assento))
            {
                Sessao.AssentosSelecionados.Remove(assento);
                btn.BackColor = Color.FromArgb(76, 175, 80);
            }
            else
            {
                Sessao.AssentosSelecionados.Add(assento);
                btn.BackColor = Color.FromArgb(255, 193, 7);
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
            var nums = new List<string>();
            foreach (var a in Sessao.AssentosSelecionados)
                nums.Add(a.QtNumero.ToString());
            lblSelecionados.Text = "Assentos selecionados: " + string.Join(", ", nums);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Sessao.AssentosSelecionados.Count == 0)
            {
                MessageBox.Show("Selecione pelo menos um assento!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            new FormConfirmacao().Show();
            this.Hide();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new FormHome().Show();
            this.Close();
        }
    }
}
