using Projeto_SIGMA.Classes.ClassesLogin;
using Projeto_SIGMA.Telas.TelasDeLogin;
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
                    btnCadastros.Enabled = false;
                }

                if (UserSession.UsuarioLogado.PermissaoConsulta == false)
                {
                    btnConsultas.Enabled = false;
                }

                if (UserSession.UsuarioLogado.PermissaoOrcamento == false)
                {
                    btnOrcamento.Enabled = false;
                }

                if (UserSession.UsuarioLogado.PermissaoPedido == false)
                {
                    btnPedido.Enabled = false;
                }
            }
        }


        public void OpenScreen(UserControl control)
        {
            if (pnlCentro.Controls.Count == 1)
                pnlCentro.Controls.RemoveAt(0);
            pnlCentro.Controls.Add(control);
        }
        

        private void btnCadastros_Click(object sender, EventArgs e)
        {
            Telas.frmCadastros tela = new Telas.frmCadastros();
            tela.Show();
            this.Hide();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            Telas.TelasDeCadastro.frmConsultas tela = new Telas.TelasDeCadastro.frmConsultas();
            tela.Show();
            this.Hide();
        }

        private void btnOrcamento_Click(object sender, EventArgs e)
        {
            Telas.TelasDePedidos.frmOrcamento tela = new Telas.TelasDePedidos.frmOrcamento();
            OpenScreen(tela);          
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            Telas.TelasDePedidos.frmServico tela = new Telas.TelasDePedidos.frmServico();
            OpenScreen(tela);

         
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            Telas.TelasDePedidos.frmEstoque tela = new Telas.TelasDePedidos.frmEstoque();
            OpenScreen(tela);       
        }

        private void btnDepto_Click(object sender, EventArgs e)
        {
            Telas.frmDepartamentos tela = new Telas.frmDepartamentos();
            OpenScreen(tela);

        }

        private void pnlCentro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_principal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin tela = new frmLogin();
            tela.Show();
            this.Close();
        }
    }
}
