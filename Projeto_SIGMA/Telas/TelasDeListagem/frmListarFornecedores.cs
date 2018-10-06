using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_SIGMA.Classes.ClassesFornecedor;
using Projeto_SIGMA.Telas.TelasDeAlterar;

namespace Projeto_SIGMA.Telas
{
    public partial class frmListarFornecedores : UserControl
    {
        public frmListarFornecedores()
        {
            InitializeComponent();
            AutoCarregar();
        }

        public void AutoCarregar()
        {
            //chamar as classes business, e colocar na lista o dto da tabela q agt quer colocar na grid.
            
            Classes.ClassesFornecedor.FornecedorBusiness business = new Classes.ClassesFornecedor.FornecedorBusiness();
            List<Classes.ClassesFornecedor.FornecedorDTO> lista = business.Listar();
            
            //AutoGenerateColums serve para impedir o DGV de gerar as colunas automaticamente.
            dgvListarFornecedores.AutoGenerateColumns = false;

            //Mandar o DGV listar tudo o que tiver na Lista de DTO.
            dgvListarFornecedores.DataSource = lista;
        }

        void CarregarGrid()
        {
            //Para cada consulta deve-se criar uma variável para armazenar.
            string nome = txtNome.Text;


            Classes.ClassesFornecedor.FornecedorBusiness business = new Classes.ClassesFornecedor.FornecedorBusiness();

            //Fazer a lista armazenar tudo o que for consultado no banco.
            List<Classes.ClassesFornecedor.FornecedorDTO> lista = business.Consultar(nome);

            dgvListarFornecedores.AutoGenerateColumns = false;
            dgvListarFornecedores.DataSource = lista;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void dgvListarFornecedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                FornecedorDTO dto = dgvListarFornecedores.Rows[e.RowIndex].DataBoundItem as FornecedorDTO;
                frmAlterarFornecedor tela = new frmAlterarFornecedor();
                tela.LoadScreen(dto);
                tela.Show();
            }

            if (e.ColumnIndex == 6)
            {
                FornecedorDTO dto = dgvListarFornecedores.Rows[e.RowIndex].DataBoundItem as FornecedorDTO;

                DialogResult resposta = MessageBox.Show("Quer mesmo apagar este registro?", "NerdT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    FornecedorBusiness business = new FornecedorBusiness();
                    business.Remover(dto.id);
                    MessageBox.Show("Registro removido com sucesso!", "NerdT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
