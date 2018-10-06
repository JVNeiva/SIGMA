using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_SIGMA.Classes.ClassesPecas;
using Projeto_SIGMA.Telas.TelasDeAlterar;

namespace Projeto_SIGMA.Telas
{
    public partial class frmListarPecas : UserControl
    {
        public frmListarPecas()
        {
            InitializeComponent();
            AutoCarregar();
        }

        public void CarregarGrid()
        {
            string nome = txtNome.Text;

            Classes.ClassesPecas.PecasBusiness business = new Classes.ClassesPecas.PecasBusiness();
            List<Classes.ClassesPecas.PecasDTO> dto = business.Consultar(nome);

            dgvPecas.AutoGenerateColumns = false;
            dgvPecas.DataSource = dto;
        }

        public void AutoCarregar()
        {
            Classes.ClassesPecas.PecasBusiness business = new Classes.ClassesPecas.PecasBusiness();
            List<Classes.ClassesPecas.PecasDTO> dto = business.Listar();

            dgvPecas.AutoGenerateColumns = false;
            dgvPecas.DataSource = dto;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void dgvPecas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                PecasDTO dto = dgvPecas.Rows[e.RowIndex].DataBoundItem as PecasDTO;
                frmAlterarPecas tela = new frmAlterarPecas();
                tela.LoadScreen(dto);
                tela.Show();
            }

            if (e.ColumnIndex == 5)
            {
                PecasDTO dto = dgvPecas.Rows[e.RowIndex].DataBoundItem as PecasDTO;

                DialogResult resposta = MessageBox.Show("Quer mesmo apagar este registro?", "NerdT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    PecasBusiness business = new PecasBusiness();
                    business.Remover(dto.Id);
                    MessageBox.Show("Registro removido com sucesso!", "NerdT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
