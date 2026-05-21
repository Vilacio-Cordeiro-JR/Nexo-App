namespace Nexo_App.UI
{
    partial class FormAssentos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAssentos));
            this.lblViagem = new System.Windows.Forms.Label();
            this.lblCorLivre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCorOcupado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCorSelecionado = new System.Windows.Forms.Label();
            this.panelAssentos = new System.Windows.Forms.Panel();
            this.lblSelecionados = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblViagem
            // 
            this.lblViagem.AutoSize = true;
            this.lblViagem.BackColor = System.Drawing.Color.Transparent;
            this.lblViagem.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViagem.ForeColor = System.Drawing.Color.Black;
            this.lblViagem.Location = new System.Drawing.Point(29, 41);
            this.lblViagem.Name = "lblViagem";
            this.lblViagem.Size = new System.Drawing.Size(266, 22);
            this.lblViagem.TabIndex = 0;
            this.lblViagem.Text = "São Paulo → Rio de Janeiro";
            // 
            // lblCorLivre
            // 
            this.lblCorLivre.AutoSize = true;
            this.lblCorLivre.BackColor = System.Drawing.Color.Green;
            this.lblCorLivre.Location = new System.Drawing.Point(353, 116);
            this.lblCorLivre.Name = "lblCorLivre";
            this.lblCorLivre.Size = new System.Drawing.Size(16, 13);
            this.lblCorLivre.TabIndex = 1;
            this.lblCorLivre.Text = "   ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(375, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "LIVRE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(459, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "OCUPADO";
            // 
            // lblCorOcupado
            // 
            this.lblCorOcupado.AutoSize = true;
            this.lblCorOcupado.BackColor = System.Drawing.Color.Red;
            this.lblCorOcupado.Location = new System.Drawing.Point(437, 117);
            this.lblCorOcupado.Name = "lblCorOcupado";
            this.lblCorOcupado.Size = new System.Drawing.Size(16, 13);
            this.lblCorOcupado.TabIndex = 3;
            this.lblCorOcupado.Text = "   ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(564, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "SELECIONADO";
            // 
            // lblCorSelecionado
            // 
            this.lblCorSelecionado.AutoSize = true;
            this.lblCorSelecionado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblCorSelecionado.Location = new System.Drawing.Point(542, 118);
            this.lblCorSelecionado.Name = "lblCorSelecionado";
            this.lblCorSelecionado.Size = new System.Drawing.Size(16, 13);
            this.lblCorSelecionado.TabIndex = 5;
            this.lblCorSelecionado.Text = "   ";
            // 
            // panelAssentos
            // 
            this.panelAssentos.AutoScroll = true;
            this.panelAssentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panelAssentos.Location = new System.Drawing.Point(33, 163);
            this.panelAssentos.Name = "panelAssentos";
            this.panelAssentos.Size = new System.Drawing.Size(620, 380);
            this.panelAssentos.TabIndex = 7;
            // 
            // lblSelecionados
            // 
            this.lblSelecionados.AutoSize = true;
            this.lblSelecionados.BackColor = System.Drawing.Color.Transparent;
            this.lblSelecionados.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblSelecionados.ForeColor = System.Drawing.Color.Black;
            this.lblSelecionados.Location = new System.Drawing.Point(29, 113);
            this.lblSelecionados.Name = "lblSelecionados";
            this.lblSelecionados.Size = new System.Drawing.Size(260, 19);
            this.lblSelecionados.TabIndex = 0;
            this.lblSelecionados.Text = "Assentos selecionados: nenhum";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(96)))), ((int)(((byte)(0)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(453, 559);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(200, 40);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "Confirmar Reserva →";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Transparent;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.ForeColor = System.Drawing.Color.Black;
            this.btnVoltar.Location = new System.Drawing.Point(33, 559);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(200, 40);
            this.btnVoltar.TabIndex = 2;
            this.btnVoltar.Text = "← Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // FormAssentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::Nexo_App.Properties.Resources.nexobackcadas;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 611);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.panelAssentos);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSelecionados);
            this.Controls.Add(this.lblCorSelecionado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCorOcupado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCorLivre);
            this.Controls.Add(this.lblViagem);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAssentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleção de Assentos";
            this.Load += new System.EventHandler(this.FormAssentos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblViagem;
        private System.Windows.Forms.Label lblCorLivre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCorOcupado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCorSelecionado;
        private System.Windows.Forms.Panel panelAssentos;
        private System.Windows.Forms.Label lblSelecionados;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnConfirmar;
    }
}