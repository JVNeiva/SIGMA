using Projeto_SIGMA.Classes.ClassesLogin;
using Projeto_SIGMA.Telas;
using Projeto_SIGMA.Telas.TelasDeLogin;
using Projeto_SIGMA.Telas.TelasDePedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_SIGMA
{
    public partial class frm_principal : Form
    {
        public frm_principal()
        {
            InitializeComponent();
            Telas.frmApresentacao tela = new Telas.frmApresentacao();
            OpenScreen(tela);
            Permissoes();
        }

        void Permissoes()
        {
            if (UserSession.UsuarioLogado.PermissaoAdm == false)
            {
                if (UserSession.UsuarioLogado.PermissaoCadastro == false)
                {
                    cadastroToolStripMenuItem.Enabled = false;
                }

                if (UserSession.UsuarioLogado.PermissaoConsulta == false)
                {
                    consultaToolStripMenuItem.Enabled = false;
                }

                if (UserSession.UsuarioLogado.PermissaoOrcamento == false)
                {
                    orçamentoToolStripMenuItem.Enabled = false;
                }

                if (UserSession.UsuarioLogado.PermissaoPedido == false)
                {
                    serviçoToolStripMenuItem.Enabled = false;
                }
            }
        }


        public void OpenScreen(UserControl control)
        {
            if (pnlCentro.Controls.Count == 1)
                pnlCentro.Controls.RemoveAt(0);
            pnlCentro.Controls.Add(control);
        }
        
        private void pnlCentro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_principal_Load(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarClientes tela = new frmCadastrarClientes();
            OpenScreen(tela);
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarFuncionario tela = new frmCadastrarFuncionario();
            OpenScreen(tela);
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarFornecedor tela = new frmCadastrarFornecedor();
            OpenScreen(tela);
        }

        private void autoMóvelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarAutomovel tela = new frmCadastrarAutomovel();
            OpenScreen(tela);
        }

        private void peçasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarPecas tela = new frmCadastrarPecas();
            OpenScreen(tela);
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListarClientes tela = new frmListarClientes();
            OpenScreen(tela);
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListarFuncionarios tela = new frmListarFuncionarios();
            OpenScreen(tela);
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListarFornecedores tela = new frmListarFornecedores();
            OpenScreen(tela);
        }

        private void peçasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListarPecas tela = new frmListarPecas();
            OpenScreen(tela);
        }

        private void autoMóveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListarAutomoveis tela = new frmListarAutomoveis();
            OpenScreen(tela);
        }

        private void orçamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrcamento tela = new frmOrcamento();
            OpenScreen(tela);
        }

        private void serviçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServico tela = new frmServico();
            OpenScreen(tela);
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoque tela = new frmEstoque();
            OpenScreen(tela);
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartamentos tela = new frmDepartamentos();
            OpenScreen(tela);
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApresentacao tela = new frmApresentacao();
            OpenScreen(tela);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin tela = new frmLogin();
            tela.Show();
            this.Close();
        }
    }
}
