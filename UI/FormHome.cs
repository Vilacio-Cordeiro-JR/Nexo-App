using System;
using System.Windows.Forms;
using Nexo_App.BLL;

namespace Nexo_App.UI
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            // Mostra o nome do usuário logado
            if (Sessao.UsuarioLogado != null)
                lblBemVindo.Text = "Bem-vindo, " + Sessao.UsuarioLogado.NmUsuario + "!";

            CarregarViagens();
        }

        private void CarregarViagens()
        {
            try
            {
                dgvViagens.Rows.Clear();
                var bll = new ViagemBLL();
                var viagens = bll.ListarDisponiveis();

                foreach (var v in viagens)
                    dgvViagens.Rows.Add(
                        v.CdViagem,
                        v.NmOrigem,
                        v.NmDestino,
                        v.DtViagem.ToString("dd/MM/yyyy HH:mm"),
                        "R$ " + v.VlPreco.ToString("F2"),
                        v.QtLivres
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar viagens: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (dgvViagens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma viagem primeiro!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvViagens.SelectedRows[0];

            // Salva a viagem selecionada na sessão de forma segura contra erros de Cast
            Sessao.ViagemSelecionada = new Models.Viagem
            {
                CdViagem = Convert.ToInt32(row.Cells["colId"].Value),
                NmOrigem = row.Cells["colOrigem"].Value.ToString(),
                NmDestino = row.Cells["colDestino"].Value.ToString()
            };

            Sessao.AssentosSelecionados.Clear();

            new FormAssentos().Show();
            this.Hide();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Sessao.UsuarioLogado = null;
            new FormLogin().Show();
            this.Close();
        }
    }
}
