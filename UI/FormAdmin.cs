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
    public partial class FormAdmin : Form
    {
        private readonly ViagemBLL _viagemBll = new ViagemBLL();
        private readonly UsuarioBLL _usuarioBLL = new UsuarioBLL();
        private Viagem viagemEmEdicao = null;

        public FormAdmin()
        {
            InitializeComponent();

            // Estilização do painel da Data
            panelData.BackColor = Color.White;
            panelData.Invalidate();
            AplicarBordaArredondada(panelData, 20);
            dateTimePicker1.CalendarForeColor = Color.Black;

            // Estilização dos Botões Principais
            AplicarBordaArredondada(btnCriarViagem, 30);
            AplicarBordaArredondada(btnAtualizar, 30);

            // Estilização dos GroupBoxes
            AplicarBordaArredondada(grpRota, 15);
            AplicarBordaArredondada(grpPreco, 15);
            AplicarBordaArredondada(grpResumo, 15);

            // Configuração e Estilização Físicas do PictureBox (Quadrado Perfeito 1x1)
            picMapaAdmin.Size = new Size(150, 150);
            picMapaAdmin.SizeMode = PictureBoxSizeMode.Zoom;
            AplicarBordaArredondada(picMapaAdmin, 15);

            // Desabilita o campo de texto para o admin não digitar caminhos inválidos na mão
            txtImagemPath.Enabled = false;

            // Vincula o evento de seleção da Grid para atualizar o preview do mapa lateral
            dgvViagens.SelectionChanged += dgvViagens_SelectionChanged;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            AplicarBordaArredondada(panelData, 20);

            // Ajuste visual do DateTimePicker interno
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker1.Location = new Point(-1, -1);
            dateTimePicker1.Width = panelData.Width + 6;
            dateTimePicker1.Height = panelData.Height + 6;

            // Vincula o evento Leave nos componentes de rota para gerar o mapa automático
            txtOrigem.Leave += (s, ev) => ObterPreviaDoMapa();
            txtDestino.Leave += (s, ev) => ObterPreviaDoMapa();

            foreach (Control internalCtrl in txtOrigem.Controls)
                internalCtrl.Leave += (s, ev) => ObterPreviaDoMapa();

            foreach (Control internalCtrl in txtDestino.Controls)
                internalCtrl.Leave += (s, ev) => ObterPreviaDoMapa();

            // Inicializa as tabelas de dados assim que o formulário abre
            CarregarGridViagensAdmin();
            btnAtualizar_Click(this, EventArgs.Empty); // Carrega as reservas existentes
            CarregarGridUsuarios();
        }

        private void ObterPreviaDoMapa()
        {
            string origen = txtOrigem.Text?.Trim();
            string destino = txtDestino.Text?.Trim();

            if (!string.IsNullOrWhiteSpace(txtImagemPath.Text) && !txtImagemPath.Text.StartsWith("http"))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(origen) && !string.IsNullOrWhiteSpace(destino))
            {
                try
                {
                    string urlMapa = _viagemBll.GerarUrlMapa(origen, destino);

                    txtImagemPath.Text = urlMapa;
                    LimparImagemPictureBox(); // Evita travas de memória
                    picMapaAdmin.ImageLocation = urlMapa;
                }
                catch
                {
                    txtImagemPath.Text = "";
                    LimparImagemPictureBox();
                }
            }
        }

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

                    // Carrega a imagem liberando o arquivo do disco imediatamente (evita erro ao deletar viagem)
                    using (var stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        picMapaAdmin.Image = Image.FromStream(stream);
                    }
                }
            }
        }

        private void btnCriarViagem_Click(object sender, EventArgs e)
        {
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

                    viagemEmEdicao = null;
                    btnCriarViagem.Text = "✔ Criar Viagem";
                    txtAssentos.Enabled = true;
                }

                // Limpa os controles da tela após salvar
                LimparCampos();

                // CRUCIAL: Atualiza a lista da Grid imediatamente após salvar/editar
                CarregarGridViagensAdmin();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar operação: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtOrigem.Text = "";
            txtDestino.Text = "";
            txtPreco.Text = "";
            txtImagemPath.Text = "";
            txtAssentos.Text = "";
            LimparImagemPictureBox();
        }

        private void LimparImagemPictureBox()
        {
            if (picMapaAdmin.Image != null)
            {
                picMapaAdmin.Image.Dispose(); // Libera os recursos da imagem anterior
                picMapaAdmin.Image = null;
            }
            picMapaAdmin.ImageLocation = null;
        }

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

        private void btnSair_Click(object sender, EventArgs e)
        {
            Sessao.UsuarioLogado = null;
            new FormLogin().Show();
            this.Close();
        }

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

                using (Pen pen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };
        }

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
                    v.VlPreco.ToString("C2"),
                    v.QtLivres
                );

                dgvViagens.Rows[rowIndex].Tag = v;
            }
        }

        private void dgvViagens_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvViagens.SelectedRows.Count > 0)
            {
                Viagem viagemSelecionada = dgvViagens.SelectedRows[0].Tag as Viagem;

                if (viagemSelecionada != null && !string.IsNullOrWhiteSpace(viagemSelecionada.DsImagem))
                {
                    try
                    {
                        if (viagemSelecionada.DsImagem.StartsWith("http"))
                        {
                            LimparImagemPictureBox();
                            picMapaAdmin1.ImageLocation = viagemSelecionada.DsImagem;
                        }
                        else
                        {
                            LimparImagemPictureBox();
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

        private void EditTrip_Click_1(object sender, EventArgs e)
        {
            if (dgvViagens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma viagem na tabela.");
                return;
            }

            // Pega a viagem da linha selecionada
            Viagem v = (Viagem)dgvViagens.SelectedRows[0].Tag;

            // Abre o formulário de edição
            using (var formEdit = new FormEditarViagem(v))
            {
                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    // Salva no banco através da BLL
                    _viagemBll.Alterar(formEdit.ViagemParaEditar);
                    MessageBox.Show("Viagem atualizada com sucesso!");

                    // Atualiza a grid
                    CarregarGridViagensAdmin();
                }
            }
        }

        private void DelTrip_Click_1(object sender, EventArgs e)
        {
            if (dgvViagens.SelectedRows.Count == 0) return;
            Viagem v = (Viagem)dgvViagens.SelectedRows[0].Tag;

            if (MessageBox.Show("Deseja excluir?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _viagemBll.Excluir(v.CdViagem);
                CarregarGridViagensAdmin();
            }
        }

        private void SeeTrip_Click_1(object sender, EventArgs e)
        {
            if (dgvViagens.SelectedRows.Count == 0) return;

            Sessao.ViagemSelecionada = (Viagem)dgvViagens.SelectedRows[0].Tag;
            new FormAssentos().ShowDialog();
        }

        private void dgvViagens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvViagens.SelectedRows.Count > 0)
            {
                Viagem viagemSelecionada = dgvViagens.SelectedRows[0].Tag as Viagem;

                if (viagemSelecionada != null && !string.IsNullOrWhiteSpace(viagemSelecionada.DsImagem))
                {
                    try
                    {
                        if (viagemSelecionada.DsImagem.StartsWith("http"))
                        {
                            LimparImagemPictureBox();
                            picMapaAdmin1.ImageLocation = viagemSelecionada.DsImagem;
                        }
                        else
                        {
                            LimparImagemPictureBox();
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

        private void CarregarGridUsuarios()
        {
            dgvUsuarios.Rows.Clear(); // Limpa para evitar duplicidade
            var listaUsuarios = _usuarioBLL.ListarTodos();

            foreach (var u in listaUsuarios)
            {
                // A ordem aqui DEVE ser a mesma ordem das colunas no grid
                int index = dgvUsuarios.Rows.Add(
                    u.NmUsuario,    // Coluna 1
                    u.NmEmail,      // Coluna 2
                    u.NmTelefone,   // Coluna 3
                    u.CdCep,        // Coluna 4
                    u.NmCidade,     // Coluna 5
                    u.IcTipo        // Coluna 6
                );

                dgvUsuarios.Rows[index].Tag = u; // Mantém o objeto na linha
            }
        }

        private void EditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;

            Usuario u = (Usuario)dgvUsuarios.SelectedRows[0].Tag;

            using (var form = new FormEditarUsuario(u))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // O formulário de edição devolve o objeto 'u' já com as alterações
                    _usuarioBLL.AlterarUsuario(form.UsuarioEditado);
                    CarregarGridUsuarios();
                }
            }
        }

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
                    MessageBox.Show("Usuário excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
        }

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