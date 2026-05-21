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
            this.grpResumo = new System.Windows.Forms.GroupBox();
            this.txtDuracaoAdmin = new Nexo_App.UI.RoundedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCriarViagem = new System.Windows.Forms.Button();
            this.txtImagemPath = new Nexo_App.UI.RoundedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.picMapaAdmin = new System.Windows.Forms.PictureBox();
            this.btnEscolherImagem = new System.Windows.Forms.Button();
            this.grpPreco = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPreco = new Nexo_App.UI.RoundedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAssentos = new Nexo_App.UI.RoundedTextBox();
            this.grpRota = new System.Windows.Forms.GroupBox();
            this.panelData = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrigem = new Nexo_App.UI.RoundedTextBox();
            this.txtDestino = new Nexo_App.UI.RoundedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblErroAdmin = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.colIdReserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassageiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.SeeTrip = new System.Windows.Forms.Button();
            this.DelTrip = new System.Windows.Forms.Button();
            this.EditTrip = new System.Windows.Forms.Button();
            this.picMapaAdmin1 = new System.Windows.Forms.PictureBox();
            this.dgvViagens = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.SeeUser = new System.Windows.Forms.Button();
            this.DelUser = new System.Windows.Forms.Button();
            this.EditUser = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.panelTopo = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpResumo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMapaAdmin)).BeginInit();
            this.grpPreco.SuspendLayout();
            this.grpRota.SuspendLayout();
            this.panelData.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMapaAdmin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViagens)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.panelTopo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
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
            this.tabPage1.Controls.Add(this.grpResumo);
            this.tabPage1.Controls.Add(this.grpPreco);
            this.tabPage1.Controls.Add(this.grpRota);
            this.tabPage1.Controls.Add(this.lblErroAdmin);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(826, 471);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Criar Viagem";
            // 
            // grpResumo
            // 
            this.grpResumo.Controls.Add(this.txtDuracaoAdmin);
            this.grpResumo.Controls.Add(this.label8);
            this.grpResumo.Controls.Add(this.btnCriarViagem);
            this.grpResumo.Controls.Add(this.txtImagemPath);
            this.grpResumo.Controls.Add(this.label7);
            this.grpResumo.Controls.Add(this.picMapaAdmin);
            this.grpResumo.Controls.Add(this.btnEscolherImagem);
            this.grpResumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpResumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpResumo.Location = new System.Drawing.Point(36, 246);
            this.grpResumo.Name = "grpResumo";
            this.grpResumo.Size = new System.Drawing.Size(755, 201);
            this.grpResumo.TabIndex = 23;
            this.grpResumo.TabStop = false;
            this.grpResumo.Text = "Resumo da Viagem";
            // 
            // txtDuracaoAdmin
            // 
            this.txtDuracaoAdmin.BackColor = System.Drawing.Color.Transparent;
            this.txtDuracaoAdmin.Location = new System.Drawing.Point(399, 43);
            this.txtDuracaoAdmin.MostrarBorda = true;
            this.txtDuracaoAdmin.Name = "txtDuracaoAdmin";
            this.txtDuracaoAdmin.Padding = new System.Windows.Forms.Padding(10);
            this.txtDuracaoAdmin.PasswordChar = '\0';
            this.txtDuracaoAdmin.PlaceholderText = "";
            this.txtDuracaoAdmin.Size = new System.Drawing.Size(350, 30);
            this.txtDuracaoAdmin.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(405, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "⏱ Duração: --";
            // 
            // btnCriarViagem
            // 
            this.btnCriarViagem.BackColor = System.Drawing.Color.Navy;
            this.btnCriarViagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriarViagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.btnCriarViagem.ForeColor = System.Drawing.Color.White;
            this.btnCriarViagem.Location = new System.Drawing.Point(461, 118);
            this.btnCriarViagem.Name = "btnCriarViagem";
            this.btnCriarViagem.Size = new System.Drawing.Size(218, 40);
            this.btnCriarViagem.TabIndex = 11;
            this.btnCriarViagem.Text = "✔ Criar Viagem";
            this.btnCriarViagem.UseVisualStyleBackColor = false;
            this.btnCriarViagem.Click += new System.EventHandler(this.btnCriarViagem_Click);
            // 
            // txtImagemPath
            // 
            this.txtImagemPath.BackColor = System.Drawing.Color.Transparent;
            this.txtImagemPath.Location = new System.Drawing.Point(14, 43);
            this.txtImagemPath.MostrarBorda = true;
            this.txtImagemPath.Name = "txtImagemPath";
            this.txtImagemPath.Padding = new System.Windows.Forms.Padding(10);
            this.txtImagemPath.PasswordChar = '\0';
            this.txtImagemPath.PlaceholderText = "";
            this.txtImagemPath.Size = new System.Drawing.Size(200, 30);
            this.txtImagemPath.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Imagem da Rota:";
            // 
            // picMapaAdmin
            // 
            this.picMapaAdmin.BackColor = System.Drawing.Color.White;
            this.picMapaAdmin.Location = new System.Drawing.Point(16, 79);
            this.picMapaAdmin.Name = "picMapaAdmin";
            this.picMapaAdmin.Size = new System.Drawing.Size(198, 107);
            this.picMapaAdmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMapaAdmin.TabIndex = 20;
            this.picMapaAdmin.TabStop = false;
            // 
            // btnEscolherImagem
            // 
            this.btnEscolherImagem.Location = new System.Drawing.Point(240, 43);
            this.btnEscolherImagem.Name = "btnEscolherImagem";
            this.btnEscolherImagem.Size = new System.Drawing.Size(100, 143);
            this.btnEscolherImagem.TabIndex = 19;
            this.btnEscolherImagem.Text = "📁 Escolher";
            this.btnEscolherImagem.UseVisualStyleBackColor = true;
            this.btnEscolherImagem.Click += new System.EventHandler(this.btnEscolherImagem_Click);
            // 
            // grpPreco
            // 
            this.grpPreco.Controls.Add(this.label5);
            this.grpPreco.Controls.Add(this.txtPreco);
            this.grpPreco.Controls.Add(this.label6);
            this.grpPreco.Controls.Add(this.txtAssentos);
            this.grpPreco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpPreco.Location = new System.Drawing.Point(427, 19);
            this.grpPreco.Name = "grpPreco";
            this.grpPreco.Size = new System.Drawing.Size(364, 208);
            this.grpPreco.TabIndex = 22;
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
            this.grpRota.Location = new System.Drawing.Point(36, 19);
            this.grpRota.Name = "grpRota";
            this.grpRota.Size = new System.Drawing.Size(364, 208);
            this.grpRota.TabIndex = 21;
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
            this.label2.Location = new System.Drawing.Point(13, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Origem:";
            // 
            // txtOrigem
            // 
            this.txtOrigem.BackColor = System.Drawing.Color.Transparent;
            this.txtOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Bold);
            this.txtOrigem.Location = new System.Drawing.Point(8, 40);
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
            this.txtDestino.Location = new System.Drawing.Point(8, 100);
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
            this.label3.Location = new System.Drawing.Point(13, 82);
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
            this.label4.Location = new System.Drawing.Point(13, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Data e Hora:";
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
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // tabPage3
            // 
            this.tabPage3.AllowDrop = true;
            this.tabPage3.BackgroundImage = global::Nexo_App.Properties.Resources.backbranconexo6;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.SeeTrip);
            this.tabPage3.Controls.Add(this.DelTrip);
            this.tabPage3.Controls.Add(this.EditTrip);
            this.tabPage3.Controls.Add(this.picMapaAdmin1);
            this.tabPage3.Controls.Add(this.dgvViagens);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(826, 471);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Viagens";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // SeeTrip
            // 
            this.SeeTrip.BackColor = System.Drawing.Color.Navy;
            this.SeeTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SeeTrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeeTrip.ForeColor = System.Drawing.Color.White;
            this.SeeTrip.Location = new System.Drawing.Point(678, 302);
            this.SeeTrip.Name = "SeeTrip";
            this.SeeTrip.Size = new System.Drawing.Size(142, 33);
            this.SeeTrip.TabIndex = 8;
            this.SeeTrip.Text = "Ver Viagem";
            this.SeeTrip.UseVisualStyleBackColor = false;
            this.SeeTrip.Click += new System.EventHandler(this.SeeTrip_Click_1);
            // 
            // DelTrip
            // 
            this.DelTrip.BackColor = System.Drawing.Color.Navy;
            this.DelTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelTrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelTrip.ForeColor = System.Drawing.Color.White;
            this.DelTrip.Location = new System.Drawing.Point(678, 263);
            this.DelTrip.Name = "DelTrip";
            this.DelTrip.Size = new System.Drawing.Size(142, 33);
            this.DelTrip.TabIndex = 7;
            this.DelTrip.Text = "Excluir Viagem";
            this.DelTrip.UseVisualStyleBackColor = false;
            this.DelTrip.Click += new System.EventHandler(this.DelTrip_Click_1);
            // 
            // EditTrip
            // 
            this.EditTrip.BackColor = System.Drawing.Color.Navy;
            this.EditTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditTrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditTrip.ForeColor = System.Drawing.Color.White;
            this.EditTrip.Location = new System.Drawing.Point(678, 224);
            this.EditTrip.Name = "EditTrip";
            this.EditTrip.Size = new System.Drawing.Size(142, 33);
            this.EditTrip.TabIndex = 6;
            this.EditTrip.Text = "Editar Viagem";
            this.EditTrip.UseVisualStyleBackColor = false;
            this.EditTrip.Click += new System.EventHandler(this.EditTrip_Click_1);
            // 
            // picMapaAdmin1
            // 
            this.picMapaAdmin1.BackColor = System.Drawing.Color.White;
            this.picMapaAdmin1.Location = new System.Drawing.Point(678, 24);
            this.picMapaAdmin1.Name = "picMapaAdmin1";
            this.picMapaAdmin1.Size = new System.Drawing.Size(142, 126);
            this.picMapaAdmin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMapaAdmin1.TabIndex = 5;
            this.picMapaAdmin1.TabStop = false;
            // 
            // dgvViagens
            // 
            this.dgvViagens.AllowUserToAddRows = false;
            this.dgvViagens.BackgroundColor = System.Drawing.Color.White;
            this.dgvViagens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvViagens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViagens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.colPreco,
            this.dataGridViewTextBoxColumn4});
            this.dgvViagens.Location = new System.Drawing.Point(21, 24);
            this.dgvViagens.Name = "dgvViagens";
            this.dgvViagens.ReadOnly = true;
            this.dgvViagens.RowHeadersVisible = false;
            this.dgvViagens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViagens.Size = new System.Drawing.Size(651, 312);
            this.dgvViagens.TabIndex = 4;
            this.dgvViagens.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViagens_CellContentClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Origem";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Destino";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Data";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 130;
            // 
            // colPreco
            // 
            this.colPreco.HeaderText = "Preço";
            this.colPreco.Name = "colPreco";
            this.colPreco.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Assentos Livres";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // tabPage4
            // 
            this.tabPage4.BackgroundImage = global::Nexo_App.Properties.Resources.backbranconexo6;
            this.tabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage4.Controls.Add(this.SeeUser);
            this.tabPage4.Controls.Add(this.DelUser);
            this.tabPage4.Controls.Add(this.EditUser);
            this.tabPage4.Controls.Add(this.dgvUsuarios);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(826, 471);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Usuarios";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // SeeUser
            // 
            this.SeeUser.BackColor = System.Drawing.Color.Navy;
            this.SeeUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SeeUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeeUser.ForeColor = System.Drawing.Color.White;
            this.SeeUser.Location = new System.Drawing.Point(8, 421);
            this.SeeUser.Name = "SeeUser";
            this.SeeUser.Size = new System.Drawing.Size(142, 33);
            this.SeeUser.TabIndex = 11;
            this.SeeUser.Text = "Ver Usuario";
            this.SeeUser.UseVisualStyleBackColor = false;
            this.SeeUser.Click += new System.EventHandler(this.SeeUser_Click);
            // 
            // DelUser
            // 
            this.DelUser.BackColor = System.Drawing.Color.Navy;
            this.DelUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelUser.ForeColor = System.Drawing.Color.White;
            this.DelUser.Location = new System.Drawing.Point(8, 382);
            this.DelUser.Name = "DelUser";
            this.DelUser.Size = new System.Drawing.Size(142, 33);
            this.DelUser.TabIndex = 10;
            this.DelUser.Text = "Excluir Usuario";
            this.DelUser.UseVisualStyleBackColor = false;
            this.DelUser.Click += new System.EventHandler(this.DelUser_Click);
            // 
            // EditUser
            // 
            this.EditUser.BackColor = System.Drawing.Color.Navy;
            this.EditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditUser.ForeColor = System.Drawing.Color.White;
            this.EditUser.Location = new System.Drawing.Point(8, 343);
            this.EditUser.Name = "EditUser";
            this.EditUser.Size = new System.Drawing.Size(142, 33);
            this.EditUser.TabIndex = 9;
            this.EditUser.Text = "Editar Usuario";
            this.EditUser.UseVisualStyleBackColor = false;
            this.EditUser.Click += new System.EventHandler(this.EditUser_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dgvUsuarios.Location = new System.Drawing.Point(8, 19);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(733, 312);
            this.dgvUsuarios.TabIndex = 5;
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
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(289, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Painel Administrativo";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Email";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Telefone";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "CEP";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Cidade";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 50;
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
            this.grpResumo.ResumeLayout(false);
            this.grpResumo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMapaAdmin)).EndInit();
            this.grpPreco.ResumeLayout(false);
            this.grpPreco.PerformLayout();
            this.grpRota.ResumeLayout(false);
            this.grpRota.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMapaAdmin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViagens)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
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
        private System.Windows.Forms.Label label7;
        private RoundedTextBox txtImagemPath;
        private System.Windows.Forms.Button btnEscolherImagem;
        private System.Windows.Forms.PictureBox picMapaAdmin;
        private System.Windows.Forms.GroupBox grpPreco;
        private System.Windows.Forms.GroupBox grpRota;
        private System.Windows.Forms.GroupBox grpResumo;
        private System.Windows.Forms.Label label8;
        private RoundedTextBox txtDuracaoAdmin;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvViagens;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.PictureBox picMapaAdmin1;
        private System.Windows.Forms.Button SeeTrip;
        private System.Windows.Forms.Button DelTrip;
        private System.Windows.Forms.Button EditTrip;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button SeeUser;
        private System.Windows.Forms.Button DelUser;
        private System.Windows.Forms.Button EditUser;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    }
}