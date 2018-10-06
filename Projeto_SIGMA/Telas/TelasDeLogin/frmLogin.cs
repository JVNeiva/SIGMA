using Projeto_SIGMA.Classes.ClassesLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_SIGMA.Telas.TelasDeLogin
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            LoginBusiness business = new LoginBusiness();
            string user = txtUser.Text;
            string pass = txtPass.Text;

            LoginDTO usuario = business.Logar(user, pass);


            if (usuario != null)
            {
                UserSession.UsuarioLogado = usuario;

                frm_principal tela = new frm_principal();
                tela.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nome de usuário ou senha incorretos.");
            }
        }

        private void lblRegistrar_Click(object sender, EventArgs e)
        {
            frmCadastrarLogin tela = new frmCadastrarLogin();
            tela.Show();
            this.Close();
        }
    }
}
