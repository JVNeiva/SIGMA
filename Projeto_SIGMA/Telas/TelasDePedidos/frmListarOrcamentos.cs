using Projeto_SIGMA.Classes.ClassesOrcamento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_SIGMA.Telas.TelasDePedidos
{
    public partial class frmListarOrcamentos : Form
    {
        public frmListarOrcamentos()
        {
            InitializeComponent();
            AutoCarregar();
        }


        public void AutoCarregar()
        {
            OrcamentoBusiness business = new OrcamentoBusiness();
            List<OrcamentoDTO> dto = business.Listar();

            dgvOrcamento.AutoGenerateColumns = false;
            dgvOrcamento.DataSource = dto;

        }

        private void dgvOrcamento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
