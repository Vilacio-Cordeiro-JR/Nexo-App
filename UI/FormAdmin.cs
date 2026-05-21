using Nexo_App.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Nexo_App.UI
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
            panelData.BackColor = Color.White;
            panelData.Invalidate();
            AplicarBordaArredondada(panelData, 20);
            dateTimePicker1.CalendarForeColor = Color.Black;
            AplicarBordaArredondada(btnCriarViagem, 30);
            AplicarBordaArredondada(btnAtualizar, 30);
            txtImagemPath.Enabled = false;
            AplicarBordaArredondada(grpRota, 15);
            AplicarBordaArredondada(grpPreco, 15);
            AplicarBordaArredondada(grpResumo, 15);
        }

        private void btnCriarViagem_Click(object sender, EventArgs e)
        {
            try
            {



                var bll = new ViagemBLL();
                bll.CriarViagem(
                    txtOrigem.Text,
                    txtDestino.Text,
                    dateTimePicker1.Value,
                    txtPreco.Text,
                    txtAssentos.Text
                );

                lblErroAdmin.Visible = false;
                MessageBox.Show("Viagem criada com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtOrigem.Text = "";
                txtDestino.Text = "";
                txtPreco.Text = "";
                txtAssentos.Text = "40";
            }
            catch (Exception ex)
            {
                lblErroAdmin.Text = ex.Message;
                lblErroAdmin.Visible = true;
            }
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
                MessageBox.Show("Erro ao carregar reservas: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            AplicarBordaArredondada(panelData, 20);



            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";

            // empurra um pouco para direita
            dateTimePicker1.Location = new Point(-1, -1);

            // aumenta para esconder bordas
            dateTimePicker1.Width = panelData.Width + 6;
            dateTimePicker1.Height = panelData.Height + 6;

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

        private void btnEscolherImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Escolher imagem da viagem";
            dialog.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtImagemPath.Text = dialog.FileName;
                picMapaAdmin.Image = Image.FromFile(dialog.FileName);
            }
        }

        //private void btnEscolherImagem_Click(object sender, EventArgs e)
        //{

        //}
    }
}
