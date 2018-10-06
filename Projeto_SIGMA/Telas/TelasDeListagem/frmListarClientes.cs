using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_SIGMA.Classes.ClassesClientes;
using Projeto_SIGMA.Telas.TelasDeAlterar;

namespace Projeto_SIGMA.Telas
{
    public partial class frmListarClientes : UserControl
    {
        public frmListarClientes()
        {
            InitializeComponent();
            AutoCarregar();
        }

        public void CarregarGrid()
        {
            string nome = txtNome.Text;
            string cidade = txtCidade.Text;

            Classes.ClassesClientes.ClienteBusiness business = new Classes.ClassesClientes.ClienteBusiness();
            List<Classes.ClassesClientes.ClienteDTO> dto = business.Consultar(nome, cidade);

            dgvListarClientes.AutoGenerateColumns = false;
            dgvListarClientes.DataSource = dto;
        }

        public void AutoCarregar()
        {
            Classes.ClassesClientes.ClienteBusiness business = new Classes.ClassesClientes.ClienteBusiness();
            List<Classes.ClassesClientes.ClienteDTO> dto = business.Listar();

            dgvListarClientes.AutoGenerateColumns = false;
            dgvListarClientes.DataSource = dto;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void label2_Click(object sender, EventArgs e)
        {



        }

        private void dgvListarClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                ClienteDTO dto = dgvListarClientes.Rows[e.RowIndex].DataBoundItem as ClienteDTO;
                frmAlterarCliente tela = new frmAlterarCliente();
                tela.LoadScreen(dto);
                tela.Show();
            }

            if (e.ColumnIndex == 11)
            {
                ClienteDTO dto = dgvListarClientes.Rows[e.RowIndex].DataBoundItem as ClienteDTO;

                DialogResult resposta = MessageBox.Show("Quer mesmo apagar este registro?", "NerdT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    ClienteBusiness business = new ClienteBusiness();
                    business.Remover(dto.Id);
                    MessageBox.Show("Registro removido com sucesso!", "NerdT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
