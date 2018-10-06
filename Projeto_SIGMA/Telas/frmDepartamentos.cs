using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_SIGMA.Classes.ClassesDepto;

namespace Projeto_SIGMA.Telas
{
    public partial class frmDepartamentos : UserControl
    {
        public frmDepartamentos()
        {
            InitializeComponent();
            AutoCarregar();
        }

        public void CarregarGrid()
        {
            string depto = txtProcurarDepto.Text;

            Classes.ClassesDepto.DeptoBusiness business = new Classes.ClassesDepto.DeptoBusiness();
            List<Classes.ClassesDepto.DeptoDTO> dto = business.Consultar(depto);

            dgvDepto.AutoGenerateColumns = false;
            dgvDepto.DataSource = dto;
        }

        public void AutoCarregar()
        {
            Classes.ClassesDepto.DeptoBusiness business = new Classes.ClassesDepto.DeptoBusiness();
            List<Classes.ClassesDepto.DeptoDTO> dto = business.Listar();

            dgvDepto.AutoGenerateColumns = false;
            dgvDepto.DataSource = dto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Classes.ClassesDepto.DeptoDTO dto = new Classes.ClassesDepto.DeptoDTO();
                dto.Departamento = txtDepto.Text;

                Classes.ClassesDepto.DeptoBusiness business = new Classes.ClassesDepto.DeptoBusiness();
                business.Salvar(dto);

                MessageBox.Show("Departamento cadastrado com suceso!!", "SIGMA", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CarregarGrid(); 
        }

        private void dgvDepto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DeptoDTO dto = new DeptoDTO();

                DialogResult resposta = MessageBox.Show("Quer mesmo apagar este registro?", "NerdT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    DeptoBusiness business = new DeptoBusiness();
                    business.Remover(dto.Id);
                    MessageBox.Show("Registro removido com sucesso!", "NerdT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void frmDepartamentos_Load(object sender, EventArgs e)
        {

        }
    }
}
