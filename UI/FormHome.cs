using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Nexo_App.BLL;
using Nexo_App.Models;

namespace Nexo_App.UI
{
    /// <summary>
    /// Formulário principal de navegação e busca de viagens do sistema Nexo.
    /// Gerencia filtros de busca, listagem de rotas e integração com a seleção de assentos.
    /// </summary>
    public partial class FormHome : Form
    {
        // Instância fixa da camada de regras de negócio para persistência e consulta de dados
        private readonly ViagemBLL _viagemBLL = new ViagemBLL();

        /// <summary>
        /// Construtor do formulário. Inicializa os componentes visuais do designer.
        /// </summary>
        public FormHome()
        {
            InitializeComponent();

            // ASSINATURA DE EVENTOS: Vincula os manipuladores de eventos aos componentes de tela
            // Nota de Manutenção: Garanta que essas linhas não estejam duplicadas no InitializeComponent()
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.picMapa.Click += new System.EventHandler(this.picMapa_Click);
        }

        /// <summary>
        /// Evento disparado quando o formulário é carregado na memória.
        /// Prepara o estado inicial e limpa resíduos de sessões anteriores.
        /// </summary>
        private void FormHome_Load(object sender, EventArgs e)
        {
            try
            {
                // RESET DE SESSÃO: Garante que nenhuma seleção anterior interfira na nova navegação
                Sessao.AssentosSelecionados.Clear();
                Sessao.ViagemSelecionada = null;

                // Identifica o usuário autenticado na tela de login e personaliza a interface
                if (Sessao.UsuarioLogado != null)
                    lblBemVindo.Text = $"Bem-Vindo, {Sessao.UsuarioLogado.NmUsuario}!";

                // Carga inicial de dados sem filtros aplicados
                CarregarGrid(null, null, null);
                PreencherFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inicializar página: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento de clique na PictureBox de miniatura do mapa.
        /// Abre uma janela popup modal para visualização ampliada do trajeto.
        /// </summary>
        private void picMapa_Click(object sender, EventArgs e)
        {
            // Valida se há alguma imagem carregada antes de abrir o popup
            if (picMapa.Image == null && string.IsNullOrWhiteSpace(picMapa.ImageLocation))
            {
                return;
            }

            // Criação dinâmica de um formulário customizado para exibição expandida da imagem
            using (Form formPopUp = new Form())
            {
                formPopUp.Text = "Visualização da Rota";
                formPopUp.Size = new Size(640, 640);
                formPopUp.StartPosition = FormStartPosition.CenterParent; // Centraliza em relação ao FormHome
                formPopUp.FormBorderStyle = FormBorderStyle.FixedDialog;
                formPopUp.MaximizeBox = false;
                formPopUp.MinimizeBox = false;

                PictureBox picGrande = new PictureBox();
                picGrande.Dock = DockStyle.Fill;
                picGrande.SizeMode = PictureBoxSizeMode.Zoom; // Mantém a proporção sem distorcer

                // Replica a origem da imagem com base no tipo de carregamento atual da miniatura
                if (!string.IsNullOrWhiteSpace(picMapa.ImageLocation))
                {
                    picGrande.ImageLocation = picMapa.ImageLocation;
                }
                else if (picMapa.Image != null)
                {
                    picGrande.Image = picMapa.Image;
                }

                formPopUp.Controls.Add(picGrande);
                formPopUp.ShowDialog(this); // Exibe como modal bloqueante
            }
        }

        /// <summary>
        /// Evento de clique no botão de busca. Extrai os filtros da tela e atualiza o grid.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Se o índice for 0 ("-- Selecione --"), o parâmetro é enviado como nulo para a BLL
                string origem = cmbOrigem.SelectedIndex > 0 ? cmbOrigem.SelectedItem.ToString() : null;
                string destino = cmbDestino.SelectedIndex > 0 ? cmbDestino.SelectedItem.ToString() : null;
                DateTime data = dtpData.Value;

                CarregarGrid(origem, destino, data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Consome a camada BLL para buscar as viagens e atualiza as linhas do DataGridView.
        /// </summary>
        private void CarregarGrid(string origem, string destino, DateTime? data)
        {
            dgvViagens.Rows.Clear();
            List<Viagem> viagens = _viagemBLL.ListarDisponiveis(origem, destino, data);

            foreach (var v in viagens)
            {
                // Adiciona a linha e captura o índice gerado
                int rowIndex = dgvViagens.Rows.Add(
                    v.CdViagem,
                    v.NmOrigem,
                    v.NmDestino,
                    v.DtViagem.ToString("dd/MM/yyyy HH:mm"),
                    v.VlPreco.ToString("C2"), // Formatação monetária local (R$)
                    v.QtLivres
                );

                // PADRÃO DE PROJETO: Injeta o objeto de modelo completo na propriedade Tag da linha.
                // Isso evita ter que fazer novas consultas SQL no banco quando o usuário clicar na linha.
                dgvViagens.Rows[rowIndex].Tag = v;
            }
        }

        /// <summary>
        /// Alimenta os ComboBoxes de origem e destino dinamicamente de forma única.
        /// </summary>
        private void PreencherFiltros()
        {
            var todas = _viagemBLL.ListarDisponiveis(null, null, null);

            // HashSet impede a inserção de strings duplicadas na lista de filtros
            var origens = new HashSet<string>();
            var destinos = new HashSet<string>();

            foreach (var v in todas)
            {
                origens.Add(v.NmOrigem);
                destinos.Add(v.NmDestino);
            }

            // Atualização do ComboBox de Origem
            cmbOrigem.Items.Clear();
            cmbOrigem.Items.Add("-- Selecione --");
            foreach (var o in origens) cmbOrigem.Items.Add(o);
            cmbOrigem.SelectedIndex = 0;

            // Atualização do ComboBox de Destino
            cmbDestino.Items.Clear();
            cmbDestino.Items.Add("-- Selecione --");
            foreach (var d in destinos) cmbDestino.Items.Add(d);
            cmbDestino.SelectedIndex = 0;
        }

        /// <summary>
        /// Avança para a tela de seleção de assentos vinculando a viagem escolhida.
        /// </summary>
        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            // Validação de segurança básica de interface
            if (dgvViagens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione uma viagem na tabela antes de prosseguir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Recupera o objeto completo injetado no Tag da linha selecionada
            Viagem vSelecionada = (Viagem)dgvViagens.SelectedRows[0].Tag;
            Sessao.ViagemSelecionada = vSelecionada;

            // MELHORIA DE ARQUITETURA: Abre a tela de assentos usando escopo seguro 'using'
            using (FormAssentos frmAssentos = new FormAssentos())
            {
                // Esconde temporariamente a Home para focar a experiência na seleção de assentos
                this.Hide();

                // Abre em modo diálogo bloqueante. O código da Home fica parado aqui esperando terminar.
                frmAssentos.ShowDialog();

                // Quando a tela de assentos for fechada (concluindo a compra ou cancelando), 
                // o fluxo volta para cá, a Home reaparece e atualiza o grid com as novas vagas restantes!
                this.Show();

                string origem = cmbOrigem.SelectedIndex > 0 ? cmbOrigem.SelectedItem.ToString() : null;
                string destino = cmbDestino.SelectedIndex > 0 ? cmbDestino.SelectedItem.ToString() : null;
                CarregarGrid(origem, destino, dtpData.Value);
            }
        }

        /// <summary>
        /// Realiza o logout do usuário atual e retorna para o fluxo de autenticação.
        /// </summary>
        private void btnSair_Click(object sender, EventArgs e)
        {
            // Limpa a credencial global
            Sessao.UsuarioLogado = null;

            // Fecha a tela atual. O Program.cs vai detectar que a sessão está nula 
            // e jogará o usuário de volta para a tela de Login!
            this.Close();
        }

        /// <summary>
        /// Evento disparado ao selecionar ou clicar em qualquer célula da tabela.
        /// Carrega dinamicamente a imagem do mapa/rota correspondente à viagem de forma segura.
        /// </summary>
        private void dgvViagens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignora cliques em linhas de cabeçalho (-1)
            if (e.RowIndex < 0) return;

            // Realiza o Cast seguro do objeto armazenado no Tag da linha clicada
            if (dgvViagens.Rows[e.RowIndex].Tag is Viagem viagemClicada)
            {
                // GERENCIAMENTO DE MEMÓRIA (BOA PRÁTICA GDI+):
                // bitmaps antigos precisam de descarte manual forçado (.Dispose()) no WinForms,
                // caso contrário continuam alocados na RAM, gerando vazamento de memória a cada clique.
                if (picMapa.Image != null)
                {
                    picMapa.Image.Dispose();
                    picMapa.Image = null;
                }
                picMapa.ImageLocation = null;

                lblDuracao.Text = "⏱ Duração: Sob Consulta";

                // Se não houver string de caminho cadastrada para a imagem, encerra o fluxo mantendo a caixa limpa
                if (string.IsNullOrWhiteSpace(viagemClicada.DsImagem)) return;

                try
                {
                    // CENÁRIO A: Imagem hospedada em servidor externo (Web URL)
                    if (viagemClicada.DsImagem.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        picMapa.SizeMode = PictureBoxSizeMode.Zoom;
                        picMapa.ImageLocation = viagemClicada.DsImagem; // Download síncrono/gerenciado pelo componente
                    }
                    // CENÁRIO B: Arquivo de imagem local integrado no diretório da aplicação
                    else
                    {
                        // Resolve o caminho físico absoluto com base na pasta de execução do binário (.exe)
                        string caminhoCompleto = Path.Combine(Application.StartupPath, viagemClicada.DsImagem);

                        if (File.Exists(caminhoCompleto))
                        {
                            picMapa.SizeMode = PictureBoxSizeMode.Zoom;

                            // I/O NÃO BLOQUEANTE: Ler através do FileStream impede que o Windows mantenha o arquivo físico
                            // travado em disco. O bloco 'using' fecha o arquivo imediatamente após carregar o Stream em memória.
                            using (FileStream fs = new FileStream(caminhoCompleto, FileMode.Open, FileAccess.Read))
                            {
                                picMapa.Image = Image.FromStream(fs);
                            }
                        }
                    }
                }
                catch
                {
                    // Mecanismo de Fail-Safe: Se o arquivo local estiver corrompido ou inacessível, limpa os elementos gráficos
                    // para evitar travamento ou crash na navegação do aplicativo.
                    if (picMapa.Image != null) picMapa.Image.Dispose();
                    picMapa.Image = null;
                    picMapa.ImageLocation = null;
                }
            }
        }
    }
}