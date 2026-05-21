using Nexo_App.BLL;
using System;
using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Nexo_App.UI
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
            AplicarBordaArredondada(btnSalvar, 30);
            AplicarBordaArredondada(btnBuscarCEP, 30);
            AplicarBordaArredondada(btnVoltar, 30);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Close();
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Garante que o CEP que vai para o banco tenha rigorosamente o formato 00000-000
                string cepFormatado = txtCEP.Text.Replace("-", "").Replace(" ", "").Trim();
                if (cepFormatado.Length == 8)
                {
                    cepFormatado = cepFormatado.Insert(5, "-");
                }

                // 2. Repassa os dados limpos e formatados para a regra de negócio
                var bll = new UsuarioBLL();
                bll.Cadastrar(
                    txtNome.Text,
                    txtEmail.Text,
                    txtSenha.Text,
                    txtTelefone.Text, // Certifique-se de digitar como: (11) 99999-9999
                    cepFormatado,     // Enviando o CEP garantido com traço
                    txtRua.Text,
                    txtBairro.Text,
                    txtCidade.Text,
                    txtEstado.Text
                );

                MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                new FormLogin().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                // Se a validação do Regex do Telefone na BLL falhar, ela vai aparecer de forma limpa aqui!
                lblErro.Text = ex.Message;
                lblErro.Visible = true;
            }
        }

        // Extrai valor de uma chave JSON simples sem bibliotecas externas
        private string Extrair(string json, string chave)
        {
            // O '\s*' avisa o C# para aceitar qualquer espaço que venha da API
            var m = Regex.Match(json, $"\"{chave}\"\\s*:\\s*\"([^\"]+)\"");
            return m.Success ? m.Groups[1].Value : "";
        }

        private void AplicarBordaArredondada(Control ctrl, int raio)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(ctrl.Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(ctrl.Width - raio, ctrl.Height - raio, raio, raio, 0, 90);
            path.AddArc(0, ctrl.Height - raio, raio, raio, 90, 90);
            path.CloseAllFigures();
            ctrl.Region = new Region(path);
        }
    }
}
