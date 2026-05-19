using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Nexo_App.UI
{
    public class RoundedTextBox : UserControl
    {
        private TextBox textBox;
        private int borderRadius = 12;
        private Color borderColor = Color.FromArgb(60, 60, 60);
        private Color focusColor = Color.FromArgb(33, 150, 243);

        public string PlaceholderText { get; set; } = "";
        public char PasswordChar
        {
            get => textBox.PasswordChar;
            set => textBox.PasswordChar = value;
        }
        public override string Text
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public RoundedTextBox()
        {
            textBox = new TextBox();
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = Color.White;
            textBox.ForeColor = Color.Black;
            textBox.Font = new Font("Segoe UI", 10);
            textBox.Dock = DockStyle.None;

            textBox.GotFocus += (s, e) => { borderColor = focusColor; Invalidate(); };
            textBox.LostFocus += (s, e) => { borderColor = Color.FromArgb(70, 70, 70); Invalidate(); };

            this.Controls.Add(textBox);
            this.BackColor = Color.White;
            this.Height = 45;
            this.Padding = new Padding(10, 10, 10, 10);
            this.DoubleBuffered = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            textBox.Width = this.Width - 24;
            textBox.Location = new Point(12, (this.Height - textBox.Height) / 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            GraphicsPath path = GetRoundedRect(rect, borderRadius);

            using (SolidBrush brush = new SolidBrush(Color.White))
                g.FillPath(brush, path);

            using (Pen pen = new Pen(borderColor, 1.5f))
                g.DrawPath(pen, path);
        }

        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}