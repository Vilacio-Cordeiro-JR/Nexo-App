namespace Nexo_App.UI
{
    partial class FormAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdmin));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelData = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCriarViagem = new System.Windows.Forms.Button();
            this.lblErroAdmin = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.colIdReserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassageiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTopo = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAssentos = new Nexo_App.UI.RoundedTextBox();
            this.txtPreco = new Nexo_App.UI.RoundedTextBox();
            this.txtDestino = new Nexo_App.UI.RoundedTextBox();
            this.txtOrigem = new Nexo_App.UI.RoundedTextBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelData.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.panelTopo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl.Location = new System.Drawing.Point(0, 61);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(834, 500);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabPage1.BackgroundImage = global::Nexo_App.Properties.Resources.backbranconexo7;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.panelData);
            this.tabPage1.Controls.Add(this.txtAssentos);
            this.tabPage1.Controls.Add(this.txtPreco);
            this.tabPage1.Controls.Add(this.txtDestino);
            this.tabPage1.Controls.Add(this.txtOrigem);
            this.tabPage1.Controls.Add(this.btnCriarViagem);
            this.tabPage1.Controls.Add(this.lblErroAdmin);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(826, 471);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Criar Viagem";
            // 
            // panelData
            // 
            this.panelData.BackColor = System.Drawing.Color.Transparent;
            this.panelData.Controls.Add(this.dateTimePicker1);
            this.panelData.Location = new System.Drawing.Point(303, 175);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(348, 30);
            this.panelData.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("Menseal Med", 12.5F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(348, 31);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // btnCriarViagem
            // 
            this.btnCriarViagem.BackColor = System.Drawing.Color.Navy;
            this.btnCriarViagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriarViagem.Font = new System.Drawing.Font("Menseal Black", 15F, System.Drawing.FontStyle.Bold);
            this.btnCriarViagem.ForeColor = System.Drawing.Color.White;
            this.btnCriarViagem.Location = new System.Drawing.Point(303, 372);
            this.btnCriarViagem.Name = "btnCriarViagem";
            this.btnCriarViagem.Size = new System.Drawing.Size(348, 40);
            this.btnCriarViagem.TabIndex = 11;
            this.btnCriarViagem.Text = "✔ Criar Viagem";
            this.btnCriarViagem.UseVisualStyleBackColor = false;
            this.btnCriarViagem.Click += new System.EventHandler(this.btnCriarViagem_Click);
            // 
            // lblErroAdmin
            // 
            this.lblErroAdmin.AutoSize = true;
            this.lblErroAdmin.BackColor = System.Drawing.Color.Transparent;
            this.lblErroAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErroAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblErroAdmin.Location = new System.Drawing.Point(300, 450);
            this.lblErroAdmin.Name = "lblErroAdmin";
            this.lblErroAdmin.Size = new System.Drawing.Size(200, 16);
            this.lblErroAdmin.TabIndex = 10;
            this.lblErroAdmin.Text = "Preencha todos os campos!";
            this.lblErroAdmin.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Menseal SemBd", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(308, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Quantidade de Assentos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Menseal SemBd", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(308, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Preço (R$):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Menseal SemBd", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(308, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Data e Hora:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Menseal SemBd", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(308, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Destino:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Menseal SemBd", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(308, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Origem:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabPage2.BackgroundImage = global::Nexo_App.Properties.Resources.backbranconexo6;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.btnAtualizar);
            this.tabPage2.Controls.Add(this.dgvReservas);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(826, 471);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ver Reservas";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.Navy;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Anton", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(5, 16);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(119, 33);
            this.btnAtualizar.TabIndex = 1;
            this.btnAtualizar.Text = "🔄";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // dgvReservas
            // 
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdReserva,
            this.colPassageiro,
            this.colOrigem,
            this.colDestino,
            this.colData,
            this.colAssentos});
            this.dgvReservas.Location = new System.Drawing.Point(133, 16);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.RowHeadersVisible = false;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.Size = new System.Drawing.Size(681, 437);
            this.dgvReservas.TabIndex = 0;
            // 
            // colIdReserva
            // 
            this.colIdReserva.HeaderText = "ID Reserva";
            this.colIdReserva.Name = "colIdReserva";
            this.colIdReserva.ReadOnly = true;
            this.colIdReserva.Width = 80;
            // 
            // colPassageiro
            // 
            this.colPassageiro.HeaderText = "Passageiro";
            this.colPassageiro.Name = "colPassageiro";
            this.colPassageiro.ReadOnly = true;
            this.colPassageiro.Width = 150;
            // 
            // colOrigem
            // 
            this.colOrigem.HeaderText = "Origem";
            this.colOrigem.Name = "colOrigem";
            this.colOrigem.ReadOnly = true;
            this.colOrigem.Width = 120;
            // 
            // colDestino
            // 
            this.colDestino.HeaderText = "Destino";
            this.colDestino.Name = "colDestino";
            this.colDestino.ReadOnly = true;
            this.colDestino.Width = 120;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 110;
            // 
            // colAssentos
            // 
            this.colAssentos.HeaderText = "Assentos";
            this.colAssentos.Name = "colAssentos";
            this.colAssentos.ReadOnly = true;
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
            this.panelTopo.Size = new System.Drawing.Size(834, 70);
            this.panelTopo.TabIndex = 0;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Menseal Black", 10F, System.Drawing.FontStyle.Bold);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(738, 20);
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
            this.label1.Font = new System.Drawing.Font("Menseal Black", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(289, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Painel Administrativo";
            // 
            // txtAssentos
            // 
            this.txtAssentos.BackColor = System.Drawing.Color.Transparent;
            this.txtAssentos.Font = new System.Drawing.Font("Menseal Med", 12.5F, System.Drawing.FontStyle.Bold);
            this.txtAssentos.Location = new System.Drawing.Point(303, 302);
            this.txtAssentos.MostrarBorda = false;
            this.txtAssentos.Name = "txtAssentos";
            this.txtAssentos.Padding = new System.Windows.Forms.Padding(10);
            this.txtAssentos.PasswordChar = '\0';
            this.txtAssentos.PlaceholderText = "";
            this.txtAssentos.Size = new System.Drawing.Size(233, 31);
            this.txtAssentos.TabIndex = 15;
            // 
            // txtPreco
            // 
            this.txtPreco.BackColor = System.Drawing.Color.Transparent;
            this.txtPreco.Font = new System.Drawing.Font("Menseal Med", 12.5F, System.Drawing.FontStyle.Bold);
            this.txtPreco.Location = new System.Drawing.Point(303, 240);
            this.txtPreco.MostrarBorda = false;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Padding = new System.Windows.Forms.Padding(10);
            this.txtPreco.PasswordChar = '\0';
            this.txtPreco.PlaceholderText = "";
            this.txtPreco.Size = new System.Drawing.Size(348, 31);
            this.txtPreco.TabIndex = 14;
            // 
            // txtDestino
            // 
            this.txtDestino.BackColor = System.Drawing.Color.Transparent;
            this.txtDestino.Font = new System.Drawing.Font("Menseal Med", 12.5F, System.Drawing.FontStyle.Bold);
            this.txtDestino.Location = new System.Drawing.Point(303, 108);
            this.txtDestino.MostrarBorda = false;
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Padding = new System.Windows.Forms.Padding(10);
            this.txtDestino.PasswordChar = '\0';
            this.txtDestino.PlaceholderText = "";
            this.txtDestino.Size = new System.Drawing.Size(348, 31);
            this.txtDestino.TabIndex = 13;
            // 
            // txtOrigem
            // 
            this.txtOrigem.BackColor = System.Drawing.Color.Transparent;
            this.txtOrigem.Font = new System.Drawing.Font("Menseal Med", 12.5F, System.Drawing.FontStyle.Bold);
            this.txtOrigem.Location = new System.Drawing.Point(303, 43);
            this.txtOrigem.MostrarBorda = false;
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Padding = new System.Windows.Forms.Padding(10);
            this.txtOrigem.PasswordChar = '\0';
            this.txtOrigem.PlaceholderText = "";
            this.txtOrigem.Size = new System.Drawing.Size(348, 31);
            this.txtOrigem.TabIndex = 12;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelTopo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Painel Administrativo";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTopo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblErroAdmin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCriarViagem;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdReserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassageiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssentos;
        private System.Windows.Forms.Button btnAtualizar;
        private RoundedTextBox txtDestino;
        private RoundedTextBox txtOrigem;
        private RoundedTextBox txtPreco;
        private RoundedTextBox txtAssentos;
        private System.Windows.Forms.Panel panelData;
    }
}