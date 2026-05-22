namespace Nexo_App.UI
{
    partial class FormEditarViagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarViagem));
            this.panelTopo = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpRota = new System.Windows.Forms.GroupBox();
            this.panelData = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrigem = new Nexo_App.UI.RoundedTextBox();
            this.txtDestino = new Nexo_App.UI.RoundedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpPreco = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPreco = new Nexo_App.UI.RoundedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAssentos = new Nexo_App.UI.RoundedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCriarViagem = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtDuracaoAdmin = new Nexo_App.UI.RoundedTextBox();
            this.panelTopo.SuspendLayout();
            this.grpRota.SuspendLayout();
            this.panelData.SuspendLayout();
            this.grpPreco.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopo
            // 
            this.panelTopo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.panelTopo.BackgroundImage = global::Nexo_App.Properties.Resources.nexopretoebranco11;
            this.panelTopo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTopo.Controls.Add(this.btnSair);
            this.panelTopo.Controls.Add(this.label1);
            this.panelTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopo.Location = new System.Drawing.Point(0, 0);
            this.panelTopo.Name = "panelTopo";
            this.panelTopo.Size = new System.Drawing.Size(800, 70);
            this.panelTopo.TabIndex = 1;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(708, 17);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(80, 35);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(289, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Painel Administrativo";
            // 
            // grpRota
            // 
            this.grpRota.Controls.Add(this.panelData);
            this.grpRota.Controls.Add(this.label2);
            this.grpRota.Controls.Add(this.txtOrigem);
            this.grpRota.Controls.Add(this.txtDestino);
            this.grpRota.Controls.Add(this.label3);
            this.grpRota.Controls.Add(this.label4);
            this.grpRota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpRota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRota.Location = new System.Drawing.Point(12, 89);
            this.grpRota.Name = "grpRota";
            this.grpRota.Size = new System.Drawing.Size(364, 208);
            this.grpRota.TabIndex = 24;
            this.grpRota.TabStop = false;
            this.grpRota.Text = "Rota e Viagem";
            // 
            // panelData
            // 
            this.panelData.BackColor = System.Drawing.Color.Transparent;
            this.panelData.Controls.Add(this.dateTimePicker1);
            this.panelData.Location = new System.Drawing.Point(8, 159);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(350, 30);
            this.panelData.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(350, 26);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Origem:";
            // 
            // txtOrigem
            // 
            this.txtOrigem.BackColor = System.Drawing.Color.Transparent;
            this.txtOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Bold);
            this.txtOrigem.Location = new System.Drawing.Point(6, 48);
            this.txtOrigem.MostrarBorda = false;
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Padding = new System.Windows.Forms.Padding(10);
            this.txtOrigem.PasswordChar = '\0';
            this.txtOrigem.PlaceholderText = "";
            this.txtOrigem.Size = new System.Drawing.Size(350, 31);
            this.txtOrigem.TabIndex = 12;
            // 
            // txtDestino
            // 
            this.txtDestino.BackColor = System.Drawing.Color.Transparent;
            this.txtDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Bold);
            this.txtDestino.Location = new System.Drawing.Point(6, 100);
            this.txtDestino.MostrarBorda = false;
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Padding = new System.Windows.Forms.Padding(10);
            this.txtDestino.PasswordChar = '\0';
            this.txtDestino.PlaceholderText = "";
            this.txtDestino.Size = new System.Drawing.Size(350, 31);
            this.txtDestino.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(11, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Destino:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(11, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Data e Hora:";
            // 
            // grpPreco
            // 
            this.grpPreco.Controls.Add(this.label5);
            this.grpPreco.Controls.Add(this.txtPreco);
            this.grpPreco.Controls.Add(this.label6);
            this.grpPreco.Controls.Add(this.txtAssentos);
            this.grpPreco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpPreco.Location = new System.Drawing.Point(420, 89);
            this.grpPreco.Name = "grpPreco";
            this.grpPreco.Size = new System.Drawing.Size(364, 208);
            this.grpPreco.TabIndex = 26;
            this.grpPreco.TabStop = false;
            this.grpPreco.Text = "Preço e Capacidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(15, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Preço (R$):";
            // 
            // txtPreco
            // 
            this.txtPreco.BackColor = System.Drawing.Color.Transparent;
            this.txtPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Bold);
            this.txtPreco.Location = new System.Drawing.Point(6, 57);
            this.txtPreco.MostrarBorda = false;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Padding = new System.Windows.Forms.Padding(10);
            this.txtPreco.PasswordChar = '\0';
            this.txtPreco.PlaceholderText = "";
            this.txtPreco.Size = new System.Drawing.Size(352, 31);
            this.txtPreco.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(15, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Quantidade de Assentos:";
            // 
            // txtAssentos
            // 
            this.txtAssentos.BackColor = System.Drawing.Color.Transparent;
            this.txtAssentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Bold);
            this.txtAssentos.Location = new System.Drawing.Point(8, 136);
            this.txtAssentos.MostrarBorda = false;
            this.txtAssentos.Name = "txtAssentos";
            this.txtAssentos.Padding = new System.Windows.Forms.Padding(10);
            this.txtAssentos.PasswordChar = '\0';
            this.txtAssentos.PlaceholderText = "";
            this.txtAssentos.Size = new System.Drawing.Size(350, 31);
            this.txtAssentos.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(435, 309);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "⏱ Duração: --";
            // 
            // btnCriarViagem
            // 
            this.btnCriarViagem.BackColor = System.Drawing.Color.Navy;
            this.btnCriarViagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriarViagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.btnCriarViagem.ForeColor = System.Drawing.Color.White;
            this.btnCriarViagem.Location = new System.Drawing.Point(446, 220);
            this.btnCriarViagem.Name = "btnCriarViagem";
            this.btnCriarViagem.Size = new System.Drawing.Size(218, 40);
            this.btnCriarViagem.TabIndex = 23;
            this.btnCriarViagem.Text = "✔ Criar Viagem";
            this.btnCriarViagem.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 40);
            this.button1.TabIndex = 28;
            this.button1.Text = " Salvar Edição";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkRed;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(12, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(218, 40);
            this.button2.TabIndex = 29;
            this.button2.Text = "  Cancelar Edição";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // txtDuracaoAdmin
            // 
            this.txtDuracaoAdmin.BackColor = System.Drawing.Color.Transparent;
            this.txtDuracaoAdmin.Location = new System.Drawing.Point(426, 325);
            this.txtDuracaoAdmin.MostrarBorda = true;
            this.txtDuracaoAdmin.Name = "txtDuracaoAdmin";
            this.txtDuracaoAdmin.Padding = new System.Windows.Forms.Padding(10);
            this.txtDuracaoAdmin.PasswordChar = '\0';
            this.txtDuracaoAdmin.PlaceholderText = "";
            this.txtDuracaoAdmin.Size = new System.Drawing.Size(350, 30);
            this.txtDuracaoAdmin.TabIndex = 27;
            // 
            // FormEditarViagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Nexo_App.Properties.Resources.backbranconexo6;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpRota);
            this.Controls.Add(this.grpPreco);
            this.Controls.Add(this.txtDuracaoAdmin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCriarViagem);
            this.Controls.Add(this.panelTopo);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditarViagem";
            this.Text = "FormEditarViagem";
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            this.grpRota.ResumeLayout(false);
            this.grpRota.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.grpPreco.ResumeLayout(false);
            this.grpPreco.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTopo;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpRota;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private RoundedTextBox txtOrigem;
        private RoundedTextBox txtDestino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpPreco;
        private System.Windows.Forms.Label label5;
        private RoundedTextBox txtPreco;
        private System.Windows.Forms.Label label6;
        private RoundedTextBox txtAssentos;
        private RoundedTextBox txtDuracaoAdmin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCriarViagem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}