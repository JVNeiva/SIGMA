using MySql.Data.MySqlClient;
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
    public partial class frmCadastrarLogin : Form
    {
        public frmCadastrarLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       

            try
            {
                string usu = txtUsuario.Text;
                usu = usu.Trim();
                int qtdUsu = usu.Count();

                if (qtdUsu > 20)
                {
                    throw new Exception("O nome de usuário não pode passar de 20 caracteres");
                }
                else if (qtdUsu == 0)
                {
                    throw new Exception("O nome de usuário é obrigatório.");
                }

                string nome = txtNome.Text;
                nome = nome.Trim();
                int qtdNome = nome.Count();

                if (qtdNome > 50)
                {
                    throw new Exception("O nome não pode passar de 50 caracteres");
                }
                else if (qtdNome == 0)
                {
                    throw new Exception("O nome é obrigatório.");
                }

                string senha = txtSenha.Text;
                int qtdSenha = senha.Count();

                if (qtdSenha > 45)
                {
                    throw new Exception("A senha não pode passar de 45 caracteres");
                }

                LoginDTO dto = new LoginDTO();
                dto.Nome = txtNome.Text;
                dto.Email = txtEmail.Text;
                dto.Usuario = txtUsuario.Text;
                dto.Senha = txtSenha.Text;
                dto.PermissaoAdm = ckbAdm.Checked;
                dto.PermissaoCadastro = ckbCadastar.Checked;
                dto.PermissaoConsulta = ckbConsultar.Checked;
                dto.PermissaoOrcamento = ckbOrcamento.Checked;
                dto.PermissaoPedido = ckbPedido.Checked;

                LoginBusiness business = new LoginBusiness();
                business.Salvar(dto);

                MessageBox.Show("Cadastro efetuado com sucesso.", "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Information);

              
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("O nome de usuário já existe.", "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void label6_Click(object sender, EventArgs e)
        {
            frmLogin tela = new frmLogin();
            tela.Show();
            this.Close();
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsWhiteSpace(e.KeyChar) == true || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
