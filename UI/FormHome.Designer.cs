namespace Nexo_App.UI
{
    partial class FormHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.lblBemVindo = new System.Windows.Forms.Label();
            this.grpBusca = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDestino = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOrigem = new System.Windows.Forms.ComboBox();
            this.labemorigem = new System.Windows.Forms.Label();
            this.dgvViagens = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.panelDetalhes = new System.Windows.Forms.Panel();
            this.lblDuracao = new System.Windows.Forms.Label();
            this.picMapa = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTopo = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.grpBusca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViagens)).BeginInit();
            this.panelDetalhes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMapa)).BeginInit();
            this.panelTopo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBemVindo
            // 
            this.lblBemVindo.AutoSize = true;
            this.lblBemVindo.BackColor = System.Drawing.Color.Transparent;
            this.lblBemVindo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblBemVindo.ForeColor = System.Drawing.Color.Black;
            this.lblBemVindo.Location = new System.Drawing.Point(12, 87);
            this.lblBemVindo.Name = "lblBemVindo";
            this.lblBemVindo.Size = new System.Drawing.Size(126, 25);
            this.lblBemVindo.TabIndex = 1;
            this.lblBemVindo.Text = "Bem-Vindo!";
            // 
            // grpBusca
            // 
            this.grpBusca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.grpBusca.Controls.Add(this.btnBuscar);
            this.grpBusca.Controls.Add(this.dtpData);
            this.grpBusca.Controls.Add(this.label2);
            this.grpBusca.Controls.Add(this.cmbDestino);
            this.grpBusca.Controls.Add(this.label1);
            this.grpBusca.Controls.Add(this.cmbOrigem);
            this.grpBusca.Controls.Add(this.labemorigem);
            this.grpBusca.ForeColor = System.Drawing.Color.White;
            this.grpBusca.Location = new System.Drawing.Point(18, 129);
            this.grpBusca.Name = "grpBusca";
            this.grpBusca.Size = new System.Drawing.Size(800, 80);
            this.grpBusca.TabIndex = 2;
            this.grpBusca.TabStop = false;
            this.grpBusca.Text = "Buscar Viagem";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(684, 28);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(518, 32);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(150, 20);
            this.dtpData.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(463, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data:";
            // 
            // cmbDestino
            // 
            this.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestino.FormattingEnabled = true;
            this.cmbDestino.Location = new System.Drawing.Point(309, 31);
            this.cmbDestino.Name = "cmbDestino";
            this.cmbDestino.Size = new System.Drawing.Size(145, 21);
            this.cmbDestino.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(230, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Destino:";
            // 
            // cmbOrigem
            // 
            this.cmbOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrigem.FormattingEnabled = true;
            this.cmbOrigem.Location = new System.Drawing.Point(79, 32);
            this.cmbOrigem.Name = "cmbOrigem";
            this.cmbOrigem.Size = new System.Drawing.Size(142, 21);
            this.cmbOrigem.TabIndex = 1;
            // 
            // labemorigem
            // 
            this.labemorigem.AutoSize = true;
            this.labemorigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.labemorigem.Location = new System.Drawing.Point(6, 34);
            this.labemorigem.Name = "labemorigem";
            this.labemorigem.Size = new System.Drawing.Size(61, 16);
            this.labemorigem.TabIndex = 0;
            this.labemorigem.Text = "Origem:";
            // 
            // dgvViagens
            // 
            this.dgvViagens.AllowUserToAddRows = false;
            this.dgvViagens.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(87)))), ((int)(((byte)(152)))));
            this.dgvViagens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvViagens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViagens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colOrigem,
            this.colDestino,
            this.colData,
            this.colPreco,
            this.colAssentos});
            this.dgvViagens.Location = new System.Drawing.Point(18, 228);
            this.dgvViagens.Name = "dgvViagens";
            this.dgvViagens.ReadOnly = true;
            this.dgvViagens.RowHeadersVisible = false;
            this.dgvViagens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViagens.Size = new System.Drawing.Size(651, 312);
            this.dgvViagens.TabIndex = 3;
            this.dgvViagens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViagens_CellClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 50;
            // 
            // colOrigem
            // 
            this.colOrigem.HeaderText = "Origem";
            this.colOrigem.Name = "colOrigem";
            this.colOrigem.ReadOnly = true;
            this.colOrigem.Width = 150;
            // 
            // colDestino
            // 
            this.colDestino.HeaderText = "Destino";
            this.colDestino.Name = "colDestino";
            this.colDestino.ReadOnly = true;
            this.colDestino.Width = 150;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 130;
            // 
            // colPreco
            // 
            this.colPreco.HeaderText = "Preço";
            this.colPreco.Name = "colPreco";
            this.colPreco.ReadOnly = true;
            // 
            // colAssentos
            // 
            this.colAssentos.HeaderText = "Assentos Livres";
            this.colAssentos.Name = "colAssentos";
            this.colAssentos.ReadOnly = true;
            this.colAssentos.Width = 120;
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.btnSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionar.ForeColor = System.Drawing.Color.White;
            this.btnSelecionar.Location = new System.Drawing.Point(11, 238);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(148, 60);
            this.btnSelecionar.TabIndex = 4;
            this.btnSelecionar.Text = "→";
            this.btnSelecionar.UseVisualStyleBackColor = false;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // panelDetalhes
            // 
            this.panelDetalhes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panelDetalhes.Controls.Add(this.lblDuracao);
            this.panelDetalhes.Controls.Add(this.btnSelecionar);
            this.panelDetalhes.Controls.Add(this.picMapa);
            this.panelDetalhes.Controls.Add(this.label3);
            this.panelDetalhes.Location = new System.Drawing.Point(667, 228);
            this.panelDetalhes.Name = "panelDetalhes";
            this.panelDetalhes.Size = new System.Drawing.Size(167, 312);
            this.panelDetalhes.TabIndex = 5;
            // 
            // lblDuracao
            // 
            this.lblDuracao.AutoSize = true;
            this.lblDuracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuracao.ForeColor = System.Drawing.Color.White;
            this.lblDuracao.Location = new System.Drawing.Point(8, 201);
            this.lblDuracao.Name = "lblDuracao";
            this.lblDuracao.Size = new System.Drawing.Size(84, 16);
            this.lblDuracao.TabIndex = 2;
            this.lblDuracao.Text = "Duração: --";
            // 
            // picMapa
            // 
            this.picMapa.BackColor = System.Drawing.Color.Silver;
            this.picMapa.Location = new System.Drawing.Point(15, 36);
            this.picMapa.Name = "picMapa";
            this.picMapa.Size = new System.Drawing.Size(140, 140);
            this.picMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMapa.TabIndex = 1;
            this.picMapa.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(26, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Detalhes";
            // 
            // panelTopo
            // 
            this.panelTopo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(0)))), ((int)(((byte)(106)))));
            this.panelTopo.BackgroundImage = global::Nexo_App.Properties.Resources.nexopretoebranco5;
            this.panelTopo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTopo.Controls.Add(this.btnSair);
            this.panelTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopo.Location = new System.Drawing.Point(0, 0);
            this.panelTopo.Name = "panelTopo";
            this.panelTopo.Size = new System.Drawing.Size(834, 70);
            this.panelTopo.TabIndex = 0;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.DarkRed;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(742, 18);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(80, 35);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::Nexo_App.Properties.Resources.backbranconexo2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.panelDetalhes);
            this.Controls.Add(this.dgvViagens);
            this.Controls.Add(this.grpBusca);
            this.Controls.Add(this.lblBemVindo);
            this.Controls.Add(this.panelTopo);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viagens Disponíveis";
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.grpBusca.ResumeLayout(false);
            this.grpBusca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViagens)).EndInit();
            this.panelDetalhes.ResumeLayout(false);
            this.panelDetalhes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMapa)).EndInit();
            this.panelTopo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTopo;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblBemVindo;
        private System.Windows.Forms.GroupBox grpBusca;
        private System.Windows.Forms.Label labemorigem;
        private System.Windows.Forms.ComboBox cmbOrigem;
        private System.Windows.Forms.ComboBox cmbDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvViagens;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssentos;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Panel panelDetalhes;
        private System.Windows.Forms.Label lblDuracao;
        private System.Windows.Forms.PictureBox picMapa;
        private System.Windows.Forms.Label label3;
    }
}