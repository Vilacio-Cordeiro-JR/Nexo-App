namespace Nexo_App.UI
{
    partial class FormCadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastro));
            this.lblNomeC = new System.Windows.Forms.Label();
            this.lblEmailC = new System.Windows.Forms.Label();
            this.lblSenhaC = new System.Windows.Forms.Label();
            this.lblTelefoneC = new System.Windows.Forms.Label();
            this.lblCepC = new System.Windows.Forms.Label();
            this.btnBuscarCEP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblErro = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.txtNome = new Nexo_App.UI.RoundedTextBox();
            this.txtEmail = new Nexo_App.UI.RoundedTextBox();
            this.txtSenha = new Nexo_App.UI.RoundedTextBox();
            this.txtTelefone = new Nexo_App.UI.RoundedTextBox();
            this.txtCEP = new Nexo_App.UI.RoundedTextBox();
            this.txtRua = new Nexo_App.UI.RoundedTextBox();
            this.txtBairro = new Nexo_App.UI.RoundedTextBox();
            this.txtCidade = new Nexo_App.UI.RoundedTextBox();
            this.txtEstado = new Nexo_App.UI.RoundedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNomeC
            // 
            this.lblNomeC.AutoSize = true;
            this.lblNomeC.BackColor = System.Drawing.Color.Transparent;
            this.lblNomeC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNomeC.ForeColor = System.Drawing.Color.Black;
            this.lblNomeC.Location = new System.Drawing.Point(76, 68);
            this.lblNomeC.Name = "lblNomeC";
            this.lblNomeC.Size = new System.Drawing.Size(120, 16);
            this.lblNomeC.TabIndex = 1;
            this.lblNomeC.Text = "Nome completo:";
            // 
            // lblEmailC
            // 
            this.lblEmailC.AutoSize = true;
            this.lblEmailC.BackColor = System.Drawing.Color.Transparent;
            this.lblEmailC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEmailC.ForeColor = System.Drawing.Color.Black;
            this.lblEmailC.Location = new System.Drawing.Point(76, 120);
            this.lblEmailC.Name = "lblEmailC";
            this.lblEmailC.Size = new System.Drawing.Size(55, 16);
            this.lblEmailC.TabIndex = 3;
            this.lblEmailC.Text = "E-mail:";
            // 
            // lblSenhaC
            // 
            this.lblSenhaC.AutoSize = true;
            this.lblSenhaC.BackColor = System.Drawing.Color.Transparent;
            this.lblSenhaC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSenhaC.ForeColor = System.Drawing.Color.Black;
            this.lblSenhaC.Location = new System.Drawing.Point(75, 172);
            this.lblSenhaC.Name = "lblSenhaC";
            this.lblSenhaC.Size = new System.Drawing.Size(55, 16);
            this.lblSenhaC.TabIndex = 5;
            this.lblSenhaC.Text = "Senha:";
            // 
            // lblTelefoneC
            // 
            this.lblTelefoneC.AutoSize = true;
            this.lblTelefoneC.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefoneC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTelefoneC.ForeColor = System.Drawing.Color.Black;
            this.lblTelefoneC.Location = new System.Drawing.Point(75, 224);
            this.lblTelefoneC.Name = "lblTelefoneC";
            this.lblTelefoneC.Size = new System.Drawing.Size(73, 16);
            this.lblTelefoneC.TabIndex = 7;
            this.lblTelefoneC.Text = "Telefone:";
            // 
            // lblCepC
            // 
            this.lblCepC.AutoSize = true;
            this.lblCepC.BackColor = System.Drawing.Color.Transparent;
            this.lblCepC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCepC.ForeColor = System.Drawing.Color.Black;
            this.lblCepC.Location = new System.Drawing.Point(275, 224);
            this.lblCepC.Name = "lblCepC";
            this.lblCepC.Size = new System.Drawing.Size(41, 16);
            this.lblCepC.TabIndex = 9;
            this.lblCepC.Text = "CEP:";
            // 
            // btnBuscarCEP
            // 
            this.btnBuscarCEP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnBuscarCEP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCEP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnBuscarCEP.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCEP.Location = new System.Drawing.Point(483, 245);
            this.btnBuscarCEP.Name = "btnBuscarCEP";
            this.btnBuscarCEP.Size = new System.Drawing.Size(108, 30);
            this.btnBuscarCEP.TabIndex = 11;
            this.btnBuscarCEP.Text = "Buscar";
            this.btnBuscarCEP.UseVisualStyleBackColor = false;
            this.btnBuscarCEP.Click += new System.EventHandler(this.btnBuscarCEP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(76, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Rua:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(75, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Bairro:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(76, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Cidade:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(75, 451);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Estado:";
            // 
            // lblErro
            // 
            this.lblErro.AutoSize = true;
            this.lblErro.BackColor = System.Drawing.Color.Transparent;
            this.lblErro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblErro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblErro.Location = new System.Drawing.Point(188, 617);
            this.lblErro.Name = "lblErro";
            this.lblErro.Size = new System.Drawing.Size(238, 13);
            this.lblErro.TabIndex = 20;
            this.lblErro.Text = "Preencha todos os campos corretamente";
            this.lblErro.Visible = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(78, 518);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(513, 40);
            this.btnSalvar.TabIndex = 21;
            this.btnSalvar.Text = "   Cadastrar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Transparent;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.btnVoltar.ForeColor = System.Drawing.Color.Black;
            this.btnVoltar.Location = new System.Drawing.Point(268, 564);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(153, 23);
            this.btnVoltar.TabIndex = 22;
            this.btnVoltar.Text = "← Voltar ao login  ";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.Transparent;
            this.txtNome.Location = new System.Drawing.Point(78, 89);
            this.txtNome.MostrarBorda = true;
            this.txtNome.Name = "txtNome";
            this.txtNome.Padding = new System.Windows.Forms.Padding(10);
            this.txtNome.PasswordChar = '\0';
            this.txtNome.PlaceholderText = "";
            this.txtNome.Size = new System.Drawing.Size(513, 28);
            this.txtNome.TabIndex = 23;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.Location = new System.Drawing.Point(79, 141);
            this.txtEmail.MostrarBorda = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Padding = new System.Windows.Forms.Padding(10);
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.Size = new System.Drawing.Size(512, 28);
            this.txtEmail.TabIndex = 24;
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.Transparent;
            this.txtSenha.Location = new System.Drawing.Point(78, 193);
            this.txtSenha.MostrarBorda = true;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Padding = new System.Windows.Forms.Padding(10);
            this.txtSenha.PasswordChar = '\0';
            this.txtSenha.PlaceholderText = "";
            this.txtSenha.Size = new System.Drawing.Size(513, 28);
            this.txtSenha.TabIndex = 25;
            // 
            // txtTelefone
            // 
            this.txtTelefone.BackColor = System.Drawing.Color.Transparent;
            this.txtTelefone.Location = new System.Drawing.Point(79, 245);
            this.txtTelefone.MostrarBorda = true;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Padding = new System.Windows.Forms.Padding(10);
            this.txtTelefone.PasswordChar = '\0';
            this.txtTelefone.PlaceholderText = "";
            this.txtTelefone.Size = new System.Drawing.Size(181, 28);
            this.txtTelefone.TabIndex = 26;
            // 
            // txtCEP
            // 
            this.txtCEP.BackColor = System.Drawing.Color.Transparent;
            this.txtCEP.Location = new System.Drawing.Point(278, 245);
            this.txtCEP.MostrarBorda = true;
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Padding = new System.Windows.Forms.Padding(10);
            this.txtCEP.PasswordChar = '\0';
            this.txtCEP.PlaceholderText = "";
            this.txtCEP.Size = new System.Drawing.Size(182, 28);
            this.txtCEP.TabIndex = 27;
            // 
            // txtRua
            // 
            this.txtRua.BackColor = System.Drawing.Color.Transparent;
            this.txtRua.Location = new System.Drawing.Point(78, 316);
            this.txtRua.MostrarBorda = true;
            this.txtRua.Name = "txtRua";
            this.txtRua.Padding = new System.Windows.Forms.Padding(10);
            this.txtRua.PasswordChar = '\0';
            this.txtRua.PlaceholderText = "";
            this.txtRua.Size = new System.Drawing.Size(513, 28);
            this.txtRua.TabIndex = 28;
            // 
            // txtBairro
            // 
            this.txtBairro.BackColor = System.Drawing.Color.Transparent;
            this.txtBairro.Location = new System.Drawing.Point(79, 368);
            this.txtBairro.MostrarBorda = true;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Padding = new System.Windows.Forms.Padding(10);
            this.txtBairro.PasswordChar = '\0';
            this.txtBairro.PlaceholderText = "";
            this.txtBairro.Size = new System.Drawing.Size(512, 28);
            this.txtBairro.TabIndex = 29;
            // 
            // txtCidade
            // 
            this.txtCidade.BackColor = System.Drawing.Color.Transparent;
            this.txtCidade.Location = new System.Drawing.Point(79, 420);
            this.txtCidade.MostrarBorda = true;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Padding = new System.Windows.Forms.Padding(10);
            this.txtCidade.PasswordChar = '\0';
            this.txtCidade.PlaceholderText = "";
            this.txtCidade.Size = new System.Drawing.Size(512, 28);
            this.txtCidade.TabIndex = 30;
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.Color.Transparent;
            this.txtEstado.Location = new System.Drawing.Point(77, 472);
            this.txtEstado.MostrarBorda = true;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Padding = new System.Windows.Forms.Padding(10);
            this.txtEstado.PasswordChar = '\0';
            this.txtEstado.PlaceholderText = "";
            this.txtEstado.Size = new System.Drawing.Size(514, 28);
            this.txtEstado.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(348, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 37);
            this.label5.TabIndex = 32;
            this.label5.Text = "Bem-Vindo!";
            // 
            // FormCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::Nexo_App.Properties.Resources.Gemini_Generated_Image_ivhtcuivhtcuivht_cleanup5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(664, 641);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.txtRua);
            this.Controls.Add(this.txtCEP);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblErro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarCEP);
            this.Controls.Add(this.lblCepC);
            this.Controls.Add(this.lblTelefoneC);
            this.Controls.Add(this.lblSenhaC);
            this.Controls.Add(this.lblEmailC);
            this.Controls.Add(this.lblNomeC);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criar Conta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNomeC;
        private System.Windows.Forms.Label lblEmailC;
        private System.Windows.Forms.Label lblSenhaC;
        private System.Windows.Forms.Label lblTelefoneC;
        private System.Windows.Forms.Label lblCepC;
        private System.Windows.Forms.Button btnBuscarCEP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblErro;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnVoltar;
        private RoundedTextBox txtNome;
        private RoundedTextBox txtEmail;
        private RoundedTextBox txtSenha;
        private RoundedTextBox txtTelefone;
        private RoundedTextBox txtCEP;
        private RoundedTextBox txtRua;
        private RoundedTextBox txtBairro;
        private RoundedTextBox txtCidade;
        private RoundedTextBox txtEstado;
        private System.Windows.Forms.Label label5;
    }
}