using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nexo_App.BLL;
using Nexo_App.Models;

namespace Nexo_App.UI
{
    /// <summary>
    /// Formulário modal de gerenciamento e edição de viagens existentes.
    /// Permite a alteração controlada de cronogramas, precificação e capacidade de lotação,
    /// protegendo campos estruturais imutáveis para garantir a consistência do sistema.
    /// </summary>
    public partial class FormEditarViagem : Form
    {
        /// <summary>
        /// Mantém a referência em memória do objeto Viagem que está sendo modificado.
        /// As alterações aplicadas aqui refletirão diretamente na coleção de origem.
        /// </summary>
        public Viagem ViagemParaEditar { get; private set; }

        /// <summary>
        /// Inicializa uma nova instância da tela de edição injetando os metadados da viagem selecionada.
        /// </summary>
        /// <param name="v">Instância da model Viagem contendo os dados atuais carregados da listagem.</param>
        public FormEditarViagem(Viagem v)
        {
            InitializeComponent();
            this.ViagemParaEditar = v;

            // =================================================================
            // CARREGAMENTO DOS DADOS DA VIAGEM NA UI
            // =================================================================
            txtOrigem.Text = v.NmOrigem;
            txtDestino.Text = v.NmDestino;
            dateTimePicker1.Value = v.DtViagem;

            // "N2" formata o valor numérico com separadores de milhar e duas casas decimais padrão
            txtPreco.Text = v.VlPreco.ToString("N2");
            txtAssentos.Text = v.QtLivres.ToString();

            // =================================================================
            // TRAVAS DE SEGURANÇA E INTEGRIDADE DE NEGÓCIO
            // =================================================================
            // Bloqueia a edição dos campos de rota após a viagem ter sido criada.
            // Isso evita inconsistências operacionais em bilhetes e reservas já vinculados.
            txtOrigem.Enabled = false;
            txtDestino.Enabled = false;
        }

        /// <summary>
        /// Evento disparado pelo botão de salvamento (btnSalvar).
        /// Realiza o parse das entradas textuais, atualiza a model por referência e fecha o modal informando sucesso.
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // =================================================================
                // ATUALIZAÇÃO SÍNCRONA DA MODEL
                // =================================================================
                ViagemParaEditar.DtViagem = dateTimePicker1.Value;

                // Converte a entrada string monetária em decimal (suporta precisão financeira)
                ViagemParaEditar.VlPreco = Convert.ToDecimal(txtPreco.Text);

                // Converte a capacidade de assentos disponíveis para inteiro de 32 bits
                ViagemParaEditar.QtLivres = Convert.ToInt32(txtAssentos.Text);

                // Define o resultado como OK, notificando a tela pai (GridView/Dashboard) 
                // de que a transação foi aceita e que a listagem de dados precisa ser atualizada.
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao converter os dados informados. Verifique a formatação do preço e assentos.\n\nDetalhes: " + ex.Message,
                    "Falha na Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento disparado pelo botão de fechamento ou cancelamento (btnCancelar).
        /// Aborta qualquer modificação efetuada nos controles gráficos e encerra o formulário de forma segura.
        /// </summary>
        private void button2_Click_1(object sender, EventArgs e)
        {
            // Define o resultado como Cancelado, indicando à tela pai que descarte as alterações temporárias
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}