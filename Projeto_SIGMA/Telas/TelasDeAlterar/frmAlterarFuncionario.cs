using MySql.Data.MySqlClient;
using Projeto_SIGMA.Classes.ClassesDepto;
using Projeto_SIGMA.Classes.ClassesFuncionarios;
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
    public partial class frmAlterarFuncionario : Form
    {
        public frmAlterarFuncionario()
        {
            InitializeComponent();
            CarregarCombos();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        FuncionarioDTO dto;

        public void LoadScreen(FuncionarioDTO dto)
        {
            this.dto = dto;
            txtNome.Text = dto.Nome;
            txtEmail.Text = dto.Email;
            mtbNasc.Text = dto.Nascimento;
            mtbTelefone.Text = dto.Telefone;
            mtbCpf.Text = dto.CPF;
            mtbRg.Text = dto.RG;
            txtCidade.Text = dto.Cidade;
            mkbEstado.Text = dto.Estado;
            txtBairro.Text = dto.Bairro;
            txtCep.Text = dto.CEP;
            txtRua.Text = dto.Rua;
            txtComplemento.Text = dto.COmplemento;
            cboDepto.SelectedItem = dto.DeptoId;
        }

        void CarregarCombos()
        {
            Classes.ClassesDepto.DeptoBusiness business = new Classes.ClassesDepto.DeptoBusiness();
            List<DeptoDTO> lista = business.Listar();

            cboDepto.ValueMember = nameof(DeptoDTO.Id);
            cboDepto.DisplayMember = nameof(DeptoDTO.Departamento);
            cboDepto.DataSource = lista;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                nome = nome.Trim();
                int qtdNome = nome.Count();

                if (qtdNome > 50)
                {
                    throw new Exception("O campo 'Nome' não pode ter mais de 50 caracteres.");
                }
                else if (qtdNome == 0)
                {
                    throw new Exception("Nome inválido.");
                }

                string cidade = txtCidade.Text;
                cidade = cidade.Trim();
                int qtdCidade = cidade.Count();

                if (qtdCidade > 50)
                {
                    throw new Exception("O campo 'Cidade' não pode ter mais de 50 caracteres.");
                }
                else if (qtdCidade == 0)
                {
                    throw new Exception("Cidade inválida.");
                }

                string bairro = txtBairro.Text;
                bairro = bairro.Trim();
                int qtdBairro = bairro.Count();

                if (qtdBairro > 451)
                {
                    throw new Exception("O campo 'Bairro' não pode ter mais de 45 caracteres.");
                }
                else if (qtdBairro == 0)
                {
                    throw new Exception("Bairro inválido.");
                }

                string rua = txtRua.Text;
                rua = rua.Trim();
                int qtdRua = rua.Count();

                if (qtdRua > 50)
                {
                    throw new Exception("Rua inválida.");
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


                DeptoDTO depto = cboDepto.SelectedItem as DeptoDTO;

                dto.Nome = txtNome.Text;
                dto.Nascimento = mtbNasc.Text;
                dto.RG = mtbRg.Text;
                dto.CPF = mtbCpf.Text;
                dto.Telefone = mtbTelefone.Text;
                dto.Email = txtEmail.Text;

                dto.DeptoId = depto.Id;

                dto.Cidade = txtCidade.Text;
                dto.Estado = mkbEstado.Text;
                dto.Bairro = txtBairro.Text;
                dto.Rua = txtRua.Text;
                dto.CEP = txtCep.Text;
                dto.COmplemento = txtComplemento.Text;

                Classes.ClassesFuncionarios.FuncionarioBusiness business = new Classes.ClassesFuncionarios.FuncionarioBusiness();
                business.Alterar(dto);

                MessageBox.Show("Funcionário alterado com suceso!!", "SIGMA", MessageBoxButtons.OK);

                frmListarFuncionarios tela = new frmListarFuncionarios();
                tela.AutoCarregar();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Funcionario já está cadastrado. Verifique se o RG ou CPF estão corretamento preenchidos ou se ele já esta no sistema.",
                        "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
