using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_SIGMA.Classes.ClassesFuncionarios;
using Projeto_SIGMA.Telas.TelasDeAlterar;

namespace Projeto_SIGMA.Telas
{
    public partial class frmListarFuncionarios : UserControl
    {
        public frmListarFuncionarios()
        {
            InitializeComponent();
            AutoCarregar();
        }

        public void CarregarGrid()
        {
            string nome = txtNome.Text;
            string cidade = txtCidade.Text; 

            Classes.ClassesFuncionarios.FuncionarioBusiness business = new Classes.ClassesFuncionarios.FuncionarioBusiness();
            List<Classes.ClassesFuncionarios.FuncionarioDTO> dto = business.Consultar(nome, cidade);

            dgvListarFuncionario.AutoGenerateColumns = false;
            dgvListarFuncionario.DataSource = dto;
        }

        public void AutoCarregar()
        {
            Classes.ClassesFuncionarios.FuncionarioBusiness business = new Classes.ClassesFuncionarios.FuncionarioBusiness();
            List<Classes.ClassesFuncionarios.FuncionarioDTO> dto = business.Listar();

            dgvListarFuncionario.AutoGenerateColumns = false;
            dgvListarFuncionario.DataSource = dto;
        }

        private void frmListarFuncionarios_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void dgvListarFuncionario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                FuncionarioDTO dto = dgvListarFuncionario.Rows[e.RowIndex].DataBoundItem as FuncionarioDTO;
                frmAlterarFuncionario tela = new frmAlterarFuncionario();
                tela.LoadScreen(dto);
                tela.Show();
            }

            if (e.ColumnIndex == 15)
            {
                FuncionarioDTO dto = dgvListarFuncionario.Rows[e.RowIndex].DataBoundItem as FuncionarioDTO;

                DialogResult resposta = MessageBox.Show("Quer mesmo apagar este registro?", "NerdT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    FuncionarioBusiness business = new FuncionarioBusiness();
                    business.Remover(dto.Id);
                    MessageBox.Show("Registro removido com sucesso!", "NerdT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
