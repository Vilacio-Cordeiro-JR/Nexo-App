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
    /// <summary>
    /// Formulário modal responsável pela edição de dados cadastrais de um usuário existente.
    /// Permite atualizar perfis de acesso, informações de contato e localização via integração ViaCEP.
    /// </summary>
    public partial class FormEditarUsuario : Form
    {
        /// <summary>
        /// Armazena o novo tipo/perfil de acesso selecionado no ComboBox para fácil leitura pelo formulário pai.
        /// </summary>
        public string NovoTipo { get; private set; }

        /// <summary>
        /// Mantém a referência em memória do objeto Usuario que está sendo modificado.
        /// </summary>
        public Usuario UsuarioEditado { get; private set; }

        /// <summary>
        /// Inicializa uma nova instância da tela de edição carregando os dados do usuário atual nos controles.
        /// </summary>
        /// <param name="u">Instância da model Usuario contendo os dados atuais vindos da listagem.</param>
        public FormEditarUsuario(Usuario u)
        {
            InitializeComponent();

            // =================================================================
            // CARREGAMENTO DOS DADOS DO USUÁRIO NA UI
            // =================================================================
            txtNome.Text = u.NmUsuario;
            txtEmail.Text = u.NmEmail;
            txtTelefone.Text = u.NmTelefone;
            txtCEP.Text = u.CdCep;
            txtRua.Text = u.NmRua;
            txtBairro.Text = u.NmBairro;
            txtCidade.Text = u.NmCidade;
            txtEstado.Text = u.SgEstado;

            // Define o item selecionado no seletor com base no indicador de tipo atual do modelo
            comboBoxTipo.SelectedItem = u.IcTipo;

            // Retém a referência do objeto original para aplicar as alterações diretamente por ponteiro de memória
            UsuarioEditado = u;
        }

        /// <summary>
        /// Coleta os dados editados nos campos textuais, atualiza a referência do objeto original
        /// e sinaliza sucesso para o fechamento controlado da janela modal.
        /// </summary>
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // =================================================================
                // ATUALIZAÇÃO DA REFERÊNCIA DO MODELO
                // =================================================================
                UsuarioEditado.NmUsuario = txtNome.Text;
                UsuarioEditado.NmEmail = txtEmail.Text;
                UsuarioEditado.NmTelefone = txtTelefone.Text;
                UsuarioEditado.CdCep = txtCEP.Text;
                UsuarioEditado.NmRua = txtRua.Text;
                UsuarioEditado.NmBairro = txtBairro.Text;
                UsuarioEditado.NmCidade = txtCidade.Text;
                UsuarioEditado.SgEstado = txtEstado.Text;

                // Valida a seleção do tipo de usuário evitando falha de conversão nula (.ToString)
                if (comboBoxTipo.SelectedItem != null)
                {
                    UsuarioEditado.IcTipo = comboBoxTipo.SelectedItem.ToString();
                }

                this.NovoTipo = comboBoxTipo.Text;

                // Define o resultado do diálogo como OK. Isso fecha automaticamente o formulário
                // modal e sinaliza ao Form pai (que chamou o ShowDialog) que a operação foi concluída com sucesso.
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Exibe feedbacks de erros que possam surgir no mapeamento ou na validação
                lblErro.Text = ex.Message;
                lblErro.Visible = true;
            }
        }

        /// <summary>
        /// Consome o serviço síncrono ViaCEP para localizar as informações logísticas do CEP informado
        /// e atualizar os campos correspondentes no formulário de edição.
        /// </summary>
        private void btnBuscarCEP_Click(object sender, EventArgs e)
        {
            // Sanitização e isolamento da string numérica de busca
            string cep = txtCEP.Text.Replace("-", "").Replace(" ", "").Trim();

            if (cep.Length != 8)
            {
                MessageBox.Show("Digite um CEP válido com 8 dígitos.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Utiliza o WebClient para realizar a requisição síncrona estruturada
                using (var wb = new System.Net.WebClient())
                {
                    wb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                    wb.Encoding = System.Text.Encoding.UTF8;

                    string json = wb.DownloadString($"http://viacep.com.br/ws/{cep}/json/");

                    // Varredura de segurança para validar se o CEP é teoricamente válido mas não consta na base postal
                    if (json.Contains("\"erro\"") || json.Contains("\"erro\": true"))
                    {
                        MessageBox.Show("CEP não encontrado ou inexistente.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Parseamento dinâmico do JSON utilizando expressões regulares locais
                    txtRua.Text = Extrair(json, "logradouro");
                    txtBairro.Text = Extrair(json, "bairro");
                    txtCidade.Text = Extrair(json, "localidade");
                    txtEstado.Text = Extrair(json, "uf");

                    // Formata a exibição do campo de CEP com a máscara amigável
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
        /// Analisa a estrutura do texto JSON e isola o valor associado a uma chave específica.
        /// Desenvolvido via Regex para eliminar o acoplamento do projeto com bibliotecas de terceiros.
        /// </summary>
        /// <param name="json">Cadeia de caracteres bruta do payload HTTP.</param>
        /// <param name="chave">Nome do nó ou propriedade que se deseja capturar.</param>
        /// <returns>Valor da propriedade localizada ou string vazia em caso de falha.</returns>
        private string Extrair(string json, string chave)
        {
            // O padrão '\s*' aceita variações de espaços em branco antes e depois dos delimitadores de par chave/valor
            var m = Regex.Match(json, $"\"{chave}\"\\s*:\\s*\"([^\"]+)\"");
            return m.Success ? m.Groups[1].Value : "";
        }
    }
}