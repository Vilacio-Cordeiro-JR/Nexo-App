using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO; // Adicionado para manipulação segura de arquivos locais
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

            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // ADICIONE ESTA LINHA: Vincula o clique da imagem ao nosso novo método
            this.picMapa.Click += new System.EventHandler(this.picMapa_Click);

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

        private void picMapa_Click(object sender, EventArgs e)
        {
            // Só abre se o PictureBox principal realmente tiver uma imagem ou URL carregada
            if (picMapa.Image == null && string.IsNullOrWhiteSpace(picMapa.ImageLocation))
            {
                return;
            }

            // 1. Cria um formulário dinâmico que vai funcionar como nossa "MessageBox de Imagem"
            using (Form formPopUp = new Form())
            {
                formPopUp.Text = "Visualização da Rota";
                formPopUp.Size = new Size(640, 640); // Tamanho grande para ver os detalhes
                formPopUp.StartPosition = FormStartPosition.CenterParent;
                formPopUp.FormBorderStyle = FormBorderStyle.FixedDialog; // Remove botões de maximizar
                formPopUp.MaximizeBox = false;
                formPopUp.MinimizeBox = false;

                // 2. Cria o PictureBox expandido dentro desse formulário
                PictureBox picGrande = new PictureBox();
                picGrande.Dock = DockStyle.Fill; // Ocupa a tela inteira do pop-up
                picGrande.SizeMode = PictureBoxSizeMode.Zoom; // Mantém a proporção sem distorcer

                // 3. Passa a imagem correta (seja URL ou arquivo local) do pai para o pop-up
                if (!string.IsNullOrWhiteSpace(picMapa.ImageLocation))
                {
                    // Se for URL da API, carrega de forma assíncrona no pop-up também
                    picGrande.ImageLocation = picMapa.ImageLocation;
                }
                else if (picMapa.Image != null)
                {
                    // Se for o upload físico local
                    picGrande.Image = picMapa.Image;
                }

                // 4. Adiciona o PictureBox ao formulário e exibe como caixa de diálogo modal
                formPopUp.Controls.Add(picGrande);
                formPopUp.ShowDialog(this);
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
                int rowIndex = dgvViagens.Rows.Add(
                    v.CdViagem,
                    v.NmOrigem,
                    v.NmDestino,
                    v.DtViagem.ToString("dd/MM/yyyy HH:mm"),
                    v.VlPreco.ToString("C2"), // Formatação de moeda local
                    v.QtLivres
                );

                // Gambiarra profissional: Vincula o objeto viagem inteiro à propriedade Tag da linha
                // para podermos resgatar o ds_imagem depois no clique da célula.
                dgvViagens.Rows[rowIndex].Tag = v;
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

            // Captura o objeto Viagem associado à linha selecionada diretamente da Tag
            Viagem vSelecionada = (Viagem)dgvViagens.SelectedRows[0].Tag;
            Sessao.ViagemSelecionada = vSelecionada;

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

        private void dgvViagens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Se clicou no cabeçalho ou fora de uma linha válida, ignora
            if (e.RowIndex < 0) return;

            // Resgata o objeto Viagem da linha clicada através da Tag
            if (dgvViagens.Rows[e.RowIndex].Tag is Viagem viagemClicada)
            {
                // Limpa renderizações antigas do PictureBox para evitar sobreposição
                picMapa.Image = null;
                picMapa.ImageLocation = null;

                // Atualiza o rótulo de duração de forma visual caso necessário, ou limpa
                lblDuracao.Text = "⏱ Duração: Sob Consulta";

                // Se não houver imagem salva no banco para essa viagem, aborta o carregamento
                if (string.IsNullOrWhiteSpace(viagemClicada.DsImagem))
                {
                    return;
                }

                try
                {
                    // CENÁRIO A: Imagem gerada automaticamente pela API do MapQuest
                    if (viagemClicada.DsImagem.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        picMapa.SizeMode = PictureBoxSizeMode.Zoom;
                        picMapa.ImageLocation = viagemClicada.DsImagem; // Baixa a imagem da internet de forma assíncrona
                    }
                    // CENÁRIO B: Imagem local enviada manualmente pelo Admin (Upload Físico)
                    else
                    {
                        // Combina o caminho de execução atual do app com o subdiretório relativo salvo no banco
                        string caminhoCompleto = Path.Combine(Application.StartupPath, viagemClicada.DsImagem);

                        if (File.Exists(caminhoCompleto))
                        {
                            picMapa.SizeMode = PictureBoxSizeMode.Zoom;
                            picMapa.Image = Image.FromFile(caminhoCompleto);
                        }
                    }
                }
                catch
                {
                    // Previne quedas do sistema caso o arquivo local seja deletado ou o cliente esteja offline
                    picMapa.Image = null;
                    picMapa.ImageLocation = null;
                }
            }
        }
    }
}