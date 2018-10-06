using MySql.Data.MySqlClient;
using Projeto_SIGMA.Classes.ClassesClientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_SIGMA.Telas.TelasDeAlterar
{
    public partial class frmAlterarCliente : Form
    {
        public frmAlterarCliente()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            frmListarClientes tela = new frmListarClientes();
            tela.AutoCarregar();

            this.Close();
        }

        ClienteDTO dto;

        public void LoadScreen(ClienteDTO dto)
        {
            this.dto = dto;
            txtNome.Text = dto.Nome;
            txtEmail.Text = dto.Email;
            mkbNascimento.Text = dto.Nascimento;
            mkbTelefone.Text = dto.Telefone;
            mkbCPF.Text = dto.CPF;
            mkbRG.Text = dto.RG;
            txtCidade.Text = dto.Cidade;
            mkbEstado.Text = dto.Estado;
            txtBairro.Text = dto.Bairro;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                nome = nome.Trim();
                int qtd = nome.Count();

                if (qtd > 50)
                {
                    throw new Exception("O campo 'Nome' não deve conter mais de 50 caracteres.");
                }
                else if (qtd == 0)
                {
                    throw new Exception("Nome inválido.");
                }

                string cidade = txtCidade.Text;
                cidade = cidade.Trim();
                int qtdCidade = cidade.Count();

                if (qtdCidade > 45)
                {
                    throw new Exception("O campo 'Cidade' não deve conter mais de 45 caracteres.");
                }
                else if (qtdCidade == 0)
                {
                    throw new Exception("Cidade inválida.");
                }

                string bairro = txtBairro.Text;
                bairro = bairro.Trim();
                int qtdBairro = cidade.Count();

                if (qtdBairro > 45)
                {
                    throw new Exception("O campo 'Bairro' não deve conter mais de 45 caracteres.");
                }
                else if (qtdBairro == 0)
                {
                    throw new Exception("Bairro inválida.");
                }

                string email = txtEmail.Text;
                email = email.Trim();
                int qtdEmail = email.Count();

                if (qtdEmail > 100)
                {
                    throw new Exception("O campo 'Email' não pode ter mais de 100 caracteres.");
                }
                else if (qtdEmail == 0)
                {
                    throw new Exception("Email inválido.");
                }


                dto.Nome = txtNome.Text;
                dto.Email = txtEmail.Text;
                dto.CPF = mkbCPF.Text;
                dto.RG = mkbRG.Text;
                dto.Nascimento = mkbNascimento.Text;
                dto.Telefone = mkbTelefone.Text;
                dto.Cidade = txtCidade.Text;
                dto.Estado = mkbEstado.Text;
                dto.Bairro = txtBairro.Text;

                Classes.ClassesClientes.ClienteBusiness business = new Classes.ClassesClientes.ClienteBusiness();
                business.Alterar(dto);

                MessageBox.Show("Cliente alterado com sucesso!", "SIGMA", MessageBoxButtons.OK);

              
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Esta pessoa já está cadastrada. Verifique se o RG ou CPF estão corretamento preenchidos ou se ela já esta no sistema."
                        , "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
