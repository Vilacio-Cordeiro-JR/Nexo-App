using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nexo_App.Models;

namespace Nexo_App.UI
{
    public partial class FormEditarViagem : Form
    {
        // Objeto para armazenar a viagem que está sendo editada
        public Viagem ViagemParaEditar { get; private set; }

        public FormEditarViagem(Viagem v)
        {
            InitializeComponent();
            this.ViagemParaEditar = v;

            // Preenche os campos com os dados atuais
            txtOrigem.Text = v.NmOrigem;
            txtDestino.Text = v.NmDestino;
            dateTimePicker1.Value = v.DtViagem;
            txtPreco.Text = v.VlPreco.ToString("N2");
            txtAssentos.Text = v.QtLivres.ToString();

            // Bloqueia origem/destino se não puderem ser alterados
            txtOrigem.Enabled = false;
            txtDestino.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Atualiza o objeto com os novos valores
            ViagemParaEditar.DtViagem = dateTimePicker1.Value;
            ViagemParaEditar.VlPreco = Convert.ToDecimal(txtPreco.Text);
            ViagemParaEditar.QtLivres = Convert.ToInt32(txtAssentos.Text);

            this.DialogResult = DialogResult.OK; // Fecha o form sinalizando sucesso
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
