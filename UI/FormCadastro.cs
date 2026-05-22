using Nexo_App.BLL;
using System;
using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Nexo_App.UI
{
    /// <summary>
    /// Formulário de interface de usuário responsável pelo fluxo de cadastro de novos integrantes.
    /// Gerencia a captura, validação de formato, consumo de API externa de endereço e persistência de dados.
    /// </summary>
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();

            // Aplica o design visual moderno com cantos arredondados nos botões principais da tela
            AplicarBordaArredondada(btnSalvar, 30);
            AplicarBordaArredondada(btnBuscarCEP, 30);
            AplicarBordaArredondada(btnVoltar, 30);
        }

        /// <summary>
        /// Cancela o fluxo de cadastro corrente e redireciona o usuário de volta para a tela de autenticação.
        /// </summary>
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Close(); // Encerra a instância atual liberando os recursos do formulário
        }

        /// <summary>
        /// Realiza uma requisição externa de forma síncrona para consultar o CEP informado
        /// e preencher automaticamente os campos de endereço do formulário.
        /// </summary>
        private void btnBuscarCEP_Click(object sender, EventArgs e)
        {
            // Sanitiza a string removendo máscaras, espaços em branco e caracteres residuais
            string cep = txtCEP.Text.Replace("-", "").Replace(" ", "").Trim();

            // Validação de consistência básica para o padrão numérico brasileiro de CEP
            if (cep.Length != 8)
            {
                MessageBox.Show("Digite um CEP válido com 8 dígitos.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Utiliza o WebClient estruturado para chamadas síncronas rápidas e diretas
                using (var wb = new System.Net.WebClient())
                {
                    // Injeta cabeçalho de User-Agent simulado para evitar bloqueios de segurança do servidor de borda (WAF)
                    wb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                    wb.Encoding = System.Text.Encoding.UTF8;

                    // Consome o endpoint rest da API pública do ViaCEP
                    string json = wb.DownloadString($"http://viacep.com.br/ws/{cep}/json/");

                    // Verifica se a API retornou uma flag interna indicando que o CEP é numericamente válido mas inexistente
                    if (json.Contains("\"erro\"") || json.Contains("\"erro\": true"))
                    {
                        MessageBox.Show("CEP não encontrado ou inexistente.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Preenche os campos textuais extraindo as chaves correspondentes do payload bruto
                    txtRua.Text = Extrair(json, "logradouro");
                    txtBairro.Text = Extrair(json, "bairro");
                    txtCidade.Text = Extrair(json, "localidade");
                    txtEstado.Text = Extrair(json, "uf");

                    // Aplica a máscara visual padrão (00000-000) de exibição amigável para o usuário
                    txtCEP.Text = cep.Insert(5, "-");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar CEP: " + ex.Message, "Erro de Conexão",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Consolida os dados do formulário, formata os parâmetros e invoca as regras 
        /// de negócio (BLL) para efetivar o registro no banco de dados.
        /// </summary>
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

                // 2. Repassa os dados limpos e formatados para a camada de regra de negócio (Business Logic Layer)
                var bll = new UsuarioBLL();
                bll.Cadastrar(
                    txtNome.Text,
                    txtEmail.Text,
                    txtSenha.Text,
                    txtTelefone.Text, // Recomenda-se o formato estruturado: (XX) XXXXX-XXXX
                    cepFormatado,     // Passagem do parâmetro de endereço devidamente normalizado
                    txtRua.Text,
                    txtBairro.Text,
                    txtCidade.Text,
                    txtEstado.Text
                );

                MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Avança o fluxo do usuário redirecionando para a tela de Login pós-sucesso
                new FormLogin().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                // Captura e renderiza feedbacks e exceções estouradas pelas validações de domínio na BLL (ex: falha no Regex do celular)
                lblErro.Text = ex.Message;
                lblErro.Visible = true;
            }
        }

        /// <summary>
        /// Extrai o valor de uma chave de string contida em uma estrutura JSON plana,
        /// eliminando a necessidade de acoplamento com parsers e dependências de terceiros (como Newtonsoft ou System.Text.Json).
        /// </summary>
        /// <param name="json">O corpo do payload retornado pela API em formato de texto.</param>
        /// <param name="chave">A propriedade que se deseja capturar o valor.</param>
        /// <returns>O valor textual associado à chave ou uma string vazia caso não encontre correspondência.</returns>
        private string Extrair(string json, string chave)
        {
            // O padrão '\s*' lida nativamente com qualquer variação de espaçamento ou quebra de linha gerada pela API
            var m = Regex.Match(json, $"\"{chave}\"\\s*:\\s*\"([^\"]+)\"");

            // Retorna o primeiro grupo de captura da expressão regular caso o mapeamento obtenha sucesso
            return m.Success ? m.Groups[1].Value : "";
        }

        /// <summary>
        /// Desenha geometricamente curvas em um elemento de controle do ecossistema Windows Forms
        /// interceptando e modificando a Região gráfica nativa do componente.
        /// </summary>
        /// <param name="ctrl">O componente visual que receberá a nova máscara (Button, Panel, etc).</param>
        /// <param name="raio">O diâmetro angular utilizado para determinar a curvatura dos cantos.</param>
        private void AplicarBordaArredondada(Control ctrl, int raio)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            // Mapeamento vetorial de arcos nos quatro quadrantes do componente (sentido horário)
            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(ctrl.Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(ctrl.Width - raio, ctrl.Height - raio, raio, raio, 0, 90);
            path.AddArc(0, ctrl.Height - raio, raio, raio, 90, 90);
            path.CloseAllFigures();

            // Substitui a região retangular padrão do sistema operacional pela nova máscara arredondada
            ctrl.Region = new Region(path);
        }
    }
}