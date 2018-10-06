using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_SIGMA.Telas.TelasDeCadastro
{
    public partial class frmConsultas : Form
    {
        public frmConsultas()
        {
            InitializeComponent();
            Telas.frmApresentacao tela = new Telas.frmApresentacao();
            OpenScreen(tela);
        }

        public void OpenScreen(UserControl control)
        {
            if (pnlCentro.Controls.Count == 1)
                pnlCentro.Controls.RemoveAt(0);
            pnlCentro.Controls.Add(control);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Telas.frmListarClientes tela = new frmListarClientes();
            OpenScreen(tela);

        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            Telas.frmListarFuncionarios tela = new frmListarFuncionarios();
            OpenScreen(tela);

        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            Telas.frmListarFornecedores tela = new frmListarFornecedores();
            OpenScreen(tela);

        }

        private void btnAutomoveis_Click(object sender, EventArgs e)
        {
            Telas.frmListarAutomoveis tela = new frmListarAutomoveis();
            OpenScreen(tela);

        }

        private void btnPecas_Click(object sender, EventArgs e)
        {
            Telas.frmListarPecas tela = new frmListarPecas();
            OpenScreen(tela);

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {            
            frm_principal tela = new frm_principal();
            tela.Show();
            this.Close();
        }

        private void frmConsultas_Load(object sender, EventArgs e)
        {

        }
    }
}
