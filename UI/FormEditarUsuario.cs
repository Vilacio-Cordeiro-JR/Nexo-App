using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.RegularExpressions;
using Nexo_App.BLL;
using Nexo_App.Models;



namespace Nexo_App.UI
{
    public partial class FormEditarUsuario : Form
    {
        public string NovoTipo { get; private set; }
        public Usuario UsuarioEditado { get; private set; }

        public FormEditarUsuario(Usuario u)
        {
            InitializeComponent();

            // Preenche os campos com os dados atuais
            txtNome.Text = u.NmUsuario;
            txtEmail.Text = u.NmEmail;
            txtTelefone.Text = u.NmTelefone;
            txtCEP.Text = u.CdCep;
            txtRua.Text = u.NmRua;
            txtBairro.Text = u.NmBairro;
            txtCidade.Text = u.NmCidade;
            txtEstado.Text = u.SgEstado;

            // Define o tipo no ComboBox
            comboBoxTipo.SelectedItem = u.IcTipo;

            // Salva a referência do usuário que está sendo editado
            UsuarioEditado = u;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Atualiza o objeto com os novos valores da UI
                UsuarioEditado.NmUsuario = txtNome.Text;
                UsuarioEditado.NmEmail = txtEmail.Text;
                UsuarioEditado.NmTelefone = txtTelefone.Text;
                UsuarioEditado.CdCep = txtCEP.Text;
                UsuarioEditado.NmRua = txtRua.Text;
                UsuarioEditado.NmBairro = txtBairro.Text;
                UsuarioEditado.NmCidade = txtCidade.Text;
                UsuarioEditado.SgEstado = txtEstado.Text;
                UsuarioEditado.IcTipo = comboBoxTipo.SelectedItem.ToString();

                this.NovoTipo = comboBoxTipo.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                lblErro.Text = ex.Message;
                lblErro.Visible = true;
            }
        }

        private string Extrair(string json, string chave)
        {
            // O '\s*' avisa o C# para aceitar qualquer espaço que venha da API
            var m = Regex.Match(json, $"\"{chave}\"\\s*:\\s*\"([^\"]+)\"");
            return m.Success ? m.Groups[1].Value : "";
        }

        private void btnBuscarCEP_Click(object sender, EventArgs e)
        {
            string cep = txtCEP.Text.Replace("-", "").Replace(" ", "").Trim();

            if (cep.Length != 8)
            {
                MessageBox.Show("Digite um CEP válido com 8 dígitos.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Usa o componente síncrono clássico do .NET para evitar erros de solicitação
                using (var wb = new System.Net.WebClient())
                {
                    wb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                    wb.Encoding = System.Text.Encoding.UTF8;

                    string json = wb.DownloadString($"http://viacep.com.br/ws/{cep}/json/");

                    if (json.Contains("\"erro\"") || json.Contains("\"erro\": true"))
                    {
                        MessageBox.Show("CEP não encontrado ou inexistente.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    txtRua.Text = Extrair(json, "logradouro");
                    txtBairro.Text = Extrair(json, "bairro");
                    txtCidade.Text = Extrair(json, "localidade");
                    txtEstado.Text = Extrair(json, "uf");

                    txtCEP.Text = cep.Insert(5, "-");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar CEP: " + ex.Message, "Erro de Conexão",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
