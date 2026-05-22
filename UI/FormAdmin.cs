using Nexo_App.BLL;
using Nexo_App.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Nexo_App.UI
{
    /// <summary>
    /// Formulário administrativo do sistema.
    /// Permite o gerenciamento de viagens, controle de assentos e visualização de usuários e reservas.
    /// </summary>
    public partial class FormAdmin : Form
    {
        // Instâncias das regras de negócio (Business Logic Layer)
        private readonly ViagemBLL _viagemBll = new ViagemBLL();
        private readonly UsuarioBLL _usuarioBLL = new UsuarioBLL();

        // Armazena a viagem que está sendo editada (nulo se o modo atual for de criação)
        private Viagem viagemEmEdicao = null;

        public FormAdmin()
        {
            InitializeComponent();

            // =================================================================
            // ESTILIZAÇÃO E IDENTIDADE VISUAL DOS COMPONENTES
            // =================================================================

            // Configuração do painel da Data
            panelData.BackColor = Color.White;
            panelData.Invalidate();
            AplicarBordaArredondada(panelData, 20);
            dateTimePicker1.CalendarForeColor = Color.Black;

            // Arredondamento dos Botões Principais (30px de raio para visual pílula)
            AplicarBordaArredondada(btnCriarViagem, 30);
            AplicarBordaArredondada(btnAtualizar, 30);

            // Arredondamento dos GroupBoxes organizadores de layout
            AplicarBordaArredondada(grpRota, 15);
            AplicarBordaArredondada(grpPreco, 15);
            AplicarBordaArredondada(grpResumo, 15);

            // Configuração física do PictureBox para manter proporções quadradas (1x1)
            picMapaAdmin.Size = new Size(150, 150);
            picMapaAdmin.SizeMode = PictureBoxSizeMode.Zoom;
            AplicarBordaArredondada(picMapaAdmin, 15);

            // Bloqueia o campo de caminho da imagem para forçar o uso do OpenFileDialog ou Mapa Automático
            txtImagemPath.Enabled = false;

            // Vincula os eventos das tabelas para gerenciar o preview do mapa em tempo real
            dgvViagens.SelectionChanged += dgvViagens_SelectionChanged;
            dgvViagens.CellContentClick += dgvViagens_SelectionChanged; // Reaproveita o mesmo método de seleção
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            AplicarBordaArredondada(panelData, 20);

            // Ajuste e dimensionamento técnico do DateTimePicker customizado dentro do painel
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker1.Location = new Point(-1, -1);
            dateTimePicker1.Width = panelData.Width + 6;
            dateTimePicker1.Height = panelData.Height + 6;

            // =================================================================
            // MAPEAMENTO DINÂMICO DE EVENTOS (LEAVE)
            // =================================================================

            // Dispara a geração automática do mapa quando o foco sai dos campos principais de rota
            txtOrigem.Leave += (s, ev) => ObterPreviaDoMapa();
            txtDestino.Leave += (s, ev) => ObterPreviaDoMapa();

            // Garante o comportamento em sub-controles internos (como em custom controls com TextBoxes aninhadas)
            foreach (Control internalCtrl in txtOrigem.Controls)
                internalCtrl.Leave += (s, ev) => ObterPreviaDoMapa();

            foreach (Control internalCtrl in txtDestino.Controls)
                internalCtrl.Leave += (s, ev) => ObterPreviaDoMapa();

            // Carga inicial dos dados no carregamento da tela
            CarregarGridViagensAdmin();
            btnAtualizar_Click(this, EventArgs.Empty); // Atualiza e lista as reservas
            CarregarGridUsuarios();
        }

        /// <summary>
        /// Solicita à camada BLL a URL estática do mapa com base na Origem e Destino informados.
        /// </summary>
        private void ObterPreviaDoMapa()
        {
            string origem = txtOrigem.Text?.Trim();
            string destino = txtDestino.Text?.Trim();

            // Se o admin selecionou um arquivo local manualmente, não sobrescreve com o mapa online
            if (!string.IsNullOrWhiteSpace(txtImagemPath.Text) && !txtImagemPath.Text.StartsWith("http"))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(origem) && !string.IsNullOrWhiteSpace(destino))
            {
                try
                {
                    // Obtém a string de conexão/API gerada pelo backend
                    string urlMapa = _viagemBll.GerarUrlMapa(origem, destino);

                    txtImagemPath.Text = urlMapa;
                    LimparImagemPictureBox(); // Evita vazamentos e travas de memória de imagens anteriores
                    picMapaAdmin.ImageLocation = urlMapa; // Carregamento assíncrono via Web URL
                }
                catch
                {
                    txtImagemPath.Text = "";
                    LimparImagemPictureBox();
                }
            }
        }

        /// <summary>
        /// Permite ao administrador selecionar uma imagem personalizada do disco rígido.
        /// </summary>
        private void btnEscolherImagem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagens (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Selecione a Imagem da Viagem (Preferencialmente Quadrada)";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImagemPath.Text = ofd.FileName;
                    LimparImagemPictureBox();

                    // CRUCIAL: Abre o arquivo através de um FileStream temporário e desvincula a imagem 
                    // do arquivo em disco imediatamente após a conversão, permitindo exclusões ou edições futuras do arquivo.
                    using (var stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        picMapaAdmin.Image = Image.FromStream(stream);
                    }
                }
            }
        }

        /// <summary>
        /// Processa a persistência da viagem (Insere um novo registro ou Altera o existente).
        /// </summary>
        private void btnCriarViagem_Click(object sender, EventArgs e)
        {
            // Validação simples de preenchimento obrigatório
            if (string.IsNullOrWhiteSpace(txtOrigem.Text) || string.IsNullOrWhiteSpace(txtDestino.Text) || string.IsNullOrWhiteSpace(txtPreco.Text))
            {
                lblErroAdmin.Visible = true;
                return;
            }
            lblErroAdmin.Visible = false;

            try
            {
                if (viagemEmEdicao == null)
                {
                    // ================== MODO: INSERIR ==================
                    Viagem novaViagem = new Viagem
                    {
                        NmOrigem = txtOrigem.Text,
                        NmDestino = txtDestino.Text,
                        DtViagem = dateTimePicker1.Value,
                        VlPreco = Convert.ToDecimal(txtPreco.Text),
                        DsImagem = txtImagemPath.Text,
                        QtLivres = string.IsNullOrWhiteSpace(txtAssentos.Text) ? 0 : Convert.ToInt32(txtAssentos.Text)
                    };

                    _viagemBll.Inserir(novaViagem);
                    MessageBox.Show("Viagem cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ================== MODO: EDITAR ==================
                    viagemEmEdicao.NmOrigem = txtOrigem.Text;
                    viagemEmEdicao.NmDestino = txtDestino.Text;
                    viagemEmEdicao.DtViagem = dateTimePicker1.Value;
                    viagemEmEdicao.VlPreco = Convert.ToDecimal(txtPreco.Text);
                    viagemEmEdicao.DsImagem = txtImagemPath.Text;

                    _viagemBll.Alterar(viagemEmEdicao);
                    MessageBox.Show("Viagem atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Restaura os controles e limpa a referência de edição
                    viagemEmEdicao = null;
                    btnCriarViagem.Text = "✔ Criar Viagem";
                    txtAssentos.Enabled = true;
                }

                // Reseta a interface do formulário e recarrega a tabela de viagens atualizada
                LimparCampos();
                CarregarGridViagensAdmin();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar operação: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpa todos os campos de entrada de dados da interface.
        /// </summary>
        private void LimparCampos()
        {
            txtOrigem.Text = "";
            txtDestino.Text = "";
            txtPreco.Text = "";
            txtImagemPath.Text = "";
            txtAssentos.Text = "";
            LimparImagemPictureBox();
        }

        /// <summary>
        /// Desvincula as imagens e executa o Dispose para evitar consumo desnecessário de memória RAM.
        /// </summary>
        private void LimparImagemPictureBox()
        {
            if (picMapaAdmin.Image != null)
            {
                picMapaAdmin.Image.Dispose(); // Libera handles gráficos do GDI+ do Windows
                picMapaAdmin.Image = null;
            }
            picMapaAdmin.ImageLocation = null;
        }

        /// <summary>
        /// Carrega e exibe a lista completa de reservas ativas registradas no banco de dados.
        /// </summary>
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReservas.Rows.Clear();
                var bll = new ReservaBLL();
                var reservas = bll.ListarTodas();

                foreach (var r in reservas)
                    dgvReservas.Rows.Add(
                        r.CdReserva,
                        r.NmUsuario,
                        r.NmOrigem,
                        r.NmDestino,
                        r.DtReserva.ToString("dd/MM/yyyy HH:mm"),
                        r.Assentos
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar reservas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Encerra a sessão administrativa e retorna para a tela de login.
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
        /// Redefine a região geométrica de um controle genérico para aplicar bordas arredondadas com contorno.
        /// </summary>
        private void AplicarBordaArredondada(Control ctrl, int raio)
        {
            ctrl.Paint += (sender, e) =>
            {
                Rectangle rect = new Rectangle(0, 0, ctrl.Width - 1, ctrl.Height - 1);

                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(rect.X, rect.Y, raio, raio, 180, 90);
                path.AddArc(rect.Right - raio, rect.Y, raio, raio, 270, 90);
                path.AddArc(rect.Right - raio, rect.Bottom - raio, raio, raio, 0, 90);
                path.AddArc(rect.X, rect.Bottom - raio, raio, raio, 90, 90);
                path.CloseFigure();

                ctrl.Region = new Region(path);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Desenha a linha externa de contorno (Preta, espessura de 2px)
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };
        }

        /// <summary>
        /// Sobrecarga específica para arredondar botões (Modifica apenas a região de corte do clique).
        /// </summary>
        private void AplicarBordaArredondada(Button btn, int raio)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(btn.Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(btn.Width - raio, btn.Height - raio, raio, raio, 0, 90);
            path.AddArc(0, btn.Height - raio, raio, raio, 90, 90);
            path.CloseAllFigures();
            btn.Region = new Region(path);
        }

        /// <summary>
        /// Carrega os registros de viagens cadastrados no Grid do Administrador.
        /// </summary>
        private void CarregarGridViagensAdmin()
        {
            dgvViagens.Rows.Clear();
            List<Viagem> viagens = _viagemBll.ListarTodas();

            foreach (var v in viagens)
            {
                int rowIndex = dgvViagens.Rows.Add(
                    v.CdViagem,
                    v.NmOrigem,
                    v.NmDestino,
                    v.DtViagem.ToString("dd/MM/yyyy HH:mm"),
                    v.VlPreco.ToString("C2"), // Formatação de moeda regional (R$)
                    v.QtLivres
                );

                // Vincula o objeto de modelo completo à linha correspondente no Grid (facilita recuperações futuras)
                dgvViagens.Rows[rowIndex].Tag = v;
            }
        }

        /// <summary>
        /// Atualiza o preview lateral da imagem/mapa da viagem sempre que o usuário clica ou navega pela Grid de Viagens.
        /// </summary>
        private void dgvViagens_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvViagens.SelectedRows.Count > 0)
            {
                // Extrai o objeto mapeado anteriormente na propriedade Tag
                Viagem viagemSelecionada = dgvViagens.SelectedRows[0].Tag as Viagem;

                if (viagemSelecionada != null && !string.IsNullOrWhiteSpace(viagemSelecionada.DsImagem))
                {
                    try
                    {
                        LimparImagemPictureBox();

                        if (viagemSelecionada.DsImagem.StartsWith("http"))
                        {
                            // Carrega remotamente caso seja uma URL estática de mapa
                            picMapaAdmin1.ImageLocation = viagemSelecionada.DsImagem;
                        }
                        else
                        {
                            // Carrega localmente por Stream seguro se o arquivo existir em disco
                            if (File.Exists(viagemSelecionada.DsImagem))
                            {
                                using (var stream = new FileStream(viagemSelecionada.DsImagem, FileMode.Open, FileAccess.Read))
                                {
                                    picMapaAdmin1.Image = Image.FromStream(stream);
                                }
                            }
                        }
                    }
                    catch
                    {
                        LimparImagemPictureBox();
                    }
                }
                else
                {
                    LimparImagemPictureBox();
                }
            }
        }

        /// <summary>
        /// Abre a janela modal externa enviando o objeto da linha selecionada para edição assistida.
        /// </summary>
        private void EditTrip_Click_1(object sender, EventArgs e)
        {
            if (dgvViagens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma viagem na tabela.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Viagem v = (Viagem)dgvViagens.SelectedRows[0].Tag;

            using (var formEdit = new FormEditarViagem(v))
            {
                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    // Se o retorno do modal for OK, salva as mudanças no banco e atualiza a tela principal
                    _viagemBll.Alterar(formEdit.ViagemParaEditar);
                    MessageBox.Show("Viagem atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarGridViagensAdmin();
                }
            }
        }

        /// <summary>
        /// Remove uma viagem do banco de dados após a confirmação expressa do administrador.
        /// </summary>
        private void DelTrip_Click_1(object sender, EventArgs e)
        {
            if (dgvViagens.SelectedRows.Count == 0) return;
            Viagem v = (Viagem)dgvViagens.SelectedRows[0].Tag;

            if (MessageBox.Show("Deseja realmente excluir esta viagem?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _viagemBll.Excluir(v.CdViagem);
                CarregarGridViagensAdmin();
            }
        }

        /// <summary>
        /// Abre a tela de gerenciamento visual do mapa de assentos para a viagem selecionada.
        /// </summary>
        private void SeeTrip_Click_1(object sender, EventArgs e)
        {
            if (dgvViagens.SelectedRows.Count == 0) return;

            // Transfere o objeto selecionado globalmente através da classe de Sessão estática
            Sessao.ViagemSelecionada = (Viagem)dgvViagens.SelectedRows[0].Tag;
            new FormAssentos().ShowDialog();
        }

        /// <summary>
        /// Carrega a tabela informativa contendo a lista completa de usuários do sistema.
        /// </summary>
        private void CarregarGridUsuarios()
        {
            dgvUsuarios.Rows.Clear();
            var listaUsuarios = _usuarioBLL.ListarTodos();

            foreach (var u in listaUsuarios)
            {
                int index = dgvUsuarios.Rows.Add(
                    u.NmUsuario,
                    u.NmEmail,
                    u.NmTelefone,
                    u.CdCep,
                    u.NmCidade,
                    u.IcTipo
                );

                // Armazena a referência completa do usuário na propriedade Tag do registro da linha
                dgvUsuarios.Rows[index].Tag = u;
            }
        }

        /// <summary>
        /// Abre o modal de edição contendo os dados do usuário selecionado no Grid.
        /// </summary>
        private void EditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;

            Usuario u = (Usuario)dgvUsuarios.SelectedRows[0].Tag;

            using (var form = new FormEditarUsuario(u))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _usuarioBLL.AlterarUsuario(form.UsuarioEditado);
                    CarregarGridUsuarios();
                }
            }
        }

        /// <summary>
        /// Executa a rotina de exclusão física do cadastro de um usuário selecionado.
        /// </summary>
        private void DelUser_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;

            Usuario u = (Usuario)dgvUsuarios.SelectedRows[0].Tag;

            if (MessageBox.Show($"Tem certeza que deseja excluir o usuário {u.NmUsuario}?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _usuarioBLL.Excluir(u.CdUsuario);
                    CarregarGridUsuarios();
                    MessageBox.Show("Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Abre um painel de mensagens rápido detalhando as informações completas e de endereço do usuário.
        /// </summary>
        private void SeeUser_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;

            Usuario u = (Usuario)dgvUsuarios.SelectedRows[0].Tag;

            string info = $"Nome: {u.NmUsuario}\n" +
                          $"Email: {u.NmEmail}\n" +
                          $"Telefone: {u.NmTelefone}\n" +
                          $"Tipo: {u.IcTipo}\n\n" +
                          $"Endereço: {u.NmRua}, {u.NmBairro}\n" +
                          $"{u.NmCidade} - {u.SgEstado}\n" +
                          $"CEP: {u.CdCep}";

            MessageBox.Show(info, "Dados do Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}