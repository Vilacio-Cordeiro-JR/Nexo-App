using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Nexo_App.BLL;
using Nexo_App.Models;

namespace Nexo_App.UI
{
    public partial class FormHome : Form
    {
        private readonly ViagemBLL _viagemBLL = new ViagemBLL();

        public FormHome()
        {
            InitializeComponent();

            // Garante o vínculo do clique do botão de busca à lógica
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            try
            {
                // Limpa a lista estática global para evitar lixo de sessões/compras passadas
                Sessao.AssentosSelecionados.Clear();
                Sessao.ViagemSelecionada = null;

                if (Sessao.UsuarioLogado != null)
                    lblBemVindo.Text = $"Bem-Vindo, {Sessao.UsuarioLogado.NmUsuario}!";

                // Inicializa o Grid com todas as viagens futuras disponíveis
                CarregarGrid(null, null, null);

                // Popula dinamicamente os ComboBoxes de filtro baseados nas viagens existentes
                PreencherFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inicializar página: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Resgata os filtros selecionados pelo usuário
                string origem = cmbOrigem.SelectedIndex > 0 ? cmbOrigem.SelectedItem.ToString() : null;
                string destino = cmbDestino.SelectedIndex > 0 ? cmbDestino.SelectedItem.ToString() : null;

                // Em sistemas de passagens, o DateTimePicker sempre vem ativo. Usamos o valor dele.
                DateTime data = dtpData.Value;

                // Executa a listagem filtrada
                CarregarGrid(origem, destino, data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CarregarGrid(string origem, string destino, DateTime? data)
        {
            dgvViagens.Rows.Clear();
            List<Viagem> viagens = _viagemBLL.ListarDisponiveis(origem, destino, data);

            foreach (var v in viagens)
            {
                dgvViagens.Rows.Add(
                    v.CdViagem,
                    v.NmOrigem,
                    v.NmDestino,
                    v.DtViagem.ToString("dd/MM/yyyy HH:mm"),
                    v.VlPreco.ToString("C2"), // Formatação de moeda local
                    v.QtLivres
                );
            }
        }

        private void PreencherFiltros()
        {
            // Busca a listagem cheia para saber quais cidades existem no banco
            var todas = _viagemBLL.ListarDisponiveis(null, null, null);

            var origens = new HashSet<string>();
            var destinos = new HashSet<string>();

            foreach (var v in todas)
            {
                origens.Add(v.NmOrigem);
                destinos.Add(v.NmDestino);
            }

            // Configura ComboBox de Origem
            cmbOrigem.Items.Clear();
            cmbOrigem.Items.Add("-- Selecione --");
            foreach (var o in origens) cmbOrigem.Items.Add(o);
            cmbOrigem.SelectedIndex = 0;

            // Configura ComboBox de Destino
            cmbDestino.Items.Clear();
            cmbDestino.Items.Add("-- Selecione --");
            foreach (var d in destinos) cmbDestino.Items.Add(d);
            cmbDestino.SelectedIndex = 0;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (dgvViagens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione uma viagem na tabela antes de prosseguir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Captura o ID oculto (colId) da linha selecionada
            int idViagem = (int)dgvViagens.SelectedRows[0].Cells["colId"].Value;

            // Busca a viagem completa na memória e guarda na sessão
            var todas = _viagemBLL.ListarDisponiveis(null, null, null);
            Sessao.ViagemSelecionada = todas.Find(x => x.CdViagem == idViagem);

            // Abre a tela de escolha de poltronas (FormAssentos)
            new FormAssentos().Show();
            this.Hide();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Sessao.UsuarioLogado = null;
            new FormLogin().Show();
            this.Close();
        }

        private void dgvViagens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Mantido apenas para evitar quebras com o designer
        }
    }
}