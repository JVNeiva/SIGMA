using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_SIGMA.Telas
{
    public partial class frmCadastros : Form
    {
        public frmCadastros()
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
            Telas.frmCadastrarClientes tela = new frmCadastrarClientes();
            OpenScreen(tela);

        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            Telas.frmCadastrarFuncionario tela = new frmCadastrarFuncionario();
            OpenScreen(tela);
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            Telas.frmCadastrarFornecedor tela = new frmCadastrarFornecedor();
            OpenScreen(tela);

        }

        private void btnAutomoveis_Click(object sender, EventArgs e)
        {
            Telas.frmCadastrarAutomovel tela = new frmCadastrarAutomovel();
            OpenScreen(tela);

        }

        private void btnPecas_Click(object sender, EventArgs e)
        {
            Telas.frmCadastrarPecas tela = new frmCadastrarPecas();
            OpenScreen(tela);

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frm_principal tela = new frm_principal();
            tela.Show();
            this.Close();
        }
    }
}
