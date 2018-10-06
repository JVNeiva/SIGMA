using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_SIGMA.Classes.ClassesAutomoveis;
using Projeto_SIGMA.Telas.TelasDeAlterar;

namespace Projeto_SIGMA.Telas
{
    public partial class frmListarAutomoveis : UserControl
    {
        public frmListarAutomoveis()
        {
            InitializeComponent();
            AutoCarregar();
        }

        public void CarregarGrid()
        {
            string marca = txtMarca.Text;
            string placa = txtPlaca.Text;
            string modelo = txtModelo.Text;

            Classes.ClassesAutomoveis.AutoBusiness business = new Classes.ClassesAutomoveis.AutoBusiness();
            List<Classes.ClassesAutomoveis.AutoDTO> dto = business.Consultar(marca, placa, modelo);

            dgvAutomoveis.AutoGenerateColumns = false;
            dgvAutomoveis.DataSource = dto;
        }

        public void AutoCarregar()
        {
            Classes.ClassesAutomoveis.AutoBusiness business = new Classes.ClassesAutomoveis.AutoBusiness();
            List<Classes.ClassesAutomoveis.AutoDTO> dto = business.Listar();

            dgvAutomoveis.AutoGenerateColumns = false;
            dgvAutomoveis.DataSource = dto;
            
        }


        private void frmListarAutomoveis_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void dgvAutomoveis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvAutomoveis.DefaultCellStyle.ForeColor = Color.Black;
            if (e.ColumnIndex == 5)
            {
                AutoDTO dto = dgvAutomoveis.Rows[e.RowIndex].DataBoundItem as AutoDTO;
                frmAlterarAutomovel tela = new frmAlterarAutomovel();
                tela.LoadScreen(dto);
                tela.Show();
            }

            if (e.ColumnIndex == 6)
            {
                AutoDTO dto = dgvAutomoveis.Rows[e.RowIndex].DataBoundItem as AutoDTO;

                DialogResult resposta = MessageBox.Show("Quer mesmo apagar este registro?", "NerdT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    AutoBusiness business = new AutoBusiness();
                    business.Remover(dto.Id);
                    MessageBox.Show("Registro removido com sucesso!", "NerdT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
