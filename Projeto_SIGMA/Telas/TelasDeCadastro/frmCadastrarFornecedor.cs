using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto_SIGMA.Telas
{
    public partial class frmCadastrarFornecedor : UserControl
    {
        public frmCadastrarFornecedor()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
           

            try
            {

                string nome = txtNomeFornecedor.Text;
                nome = nome.Trim();
                int qtdNome = nome.Count();

                if (qtdNome > 50)
                {
                    throw new Exception("O campo 'Nome' não pode conter mais de 50 caracteres.");
                }
                else if (qtdNome == 0)
                {
                    throw new Exception("Nome inválido");
                }


                string cidade = txtCidade.Text;
                cidade = cidade.Trim();
                int qtdCidade = cidade.Count();

                if (qtdCidade > 45)
                {
                    throw new Exception("O campo 'Cidade' não pode conter mais de 45 caracteres.");
                }
                else if (qtdCidade == 0)
                {
                    throw new Exception("Cidade inválida.");
                }

                Classes.ClassesFornecedor.FornecedorDTO dto = new Classes.ClassesFornecedor.FornecedorDTO();

                dto.Nome = txtNomeFornecedor.Text;
                dto.Cidade = txtCidade.Text;
                dto.Estado = mkbEstado.Text;
                dto.Discricao = txtCPF_CNPJ.Text;

                Classes.ClassesFornecedor.FornecedorBusiness business = new Classes.ClassesFornecedor.FornecedorBusiness();
                business.Salvar(dto);

                MessageBox.Show("Fornecedor cadastrado com sucesso!", "SIGMA", MessageBoxButtons.OK);
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Este fornecedor já esta cadastrado. Verifique se o CNPJ está corretamente preenchido ou se ele já está no sistema.",
                        "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtCidade_KeyPress(object sender, KeyPressEventArgs e)
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
