using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_SIGMA.Telas.TelasDePedidos
{
    public partial class frmEstoque : UserControl
    {
        public frmEstoque()
        {
            InitializeComponent();
            CarregarCboFornecedor();
            CarregarCboPeca();
            AutoCarregar();
        }

        void CarregarCboFornecedor()
        {
            Classes.ClassesFornecedor.FornecedorBusiness business = new Classes.ClassesFornecedor.FornecedorBusiness();
            List<Classes.ClassesFornecedor.FornecedorDTO> lista = business.Listar();

            cboFornecedor.ValueMember = nameof(Classes.ClassesFornecedor.FornecedorDTO.id);
            cboFornecedor.DisplayMember = nameof(Classes.ClassesFornecedor.FornecedorDTO.Nome);
            cboFornecedor.DataSource = lista;
        }

        void CarregarCboPeca()
        {
            Classes.ClassesPecas.PecasBusiness business = new Classes.ClassesPecas.PecasBusiness();
            List<Classes.ClassesPecas.PecasDTO> lista = business.Listar();

            cboPeca.ValueMember = nameof(Classes.ClassesPecas.PecasDTO.Id);
            cboPeca.DisplayMember = nameof(Classes.ClassesPecas.PecasDTO.Nome);
            cboPeca.DataSource = lista;
        }
        
        public void AutoCarregar()
        {
            Classes.ClassesEstoque.EstoqueBusiness business = new Classes.ClassesEstoque.EstoqueBusiness();
            List<Classes.ClassesEstoque.EstoqueDTO> dto = business.Listar();

            dgvEstoque.AutoGenerateColumns = false;
            dgvEstoque.DataSource = dto;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Classes.ClassesFornecedor.FornecedorDTO Fdto = cboFornecedor.SelectedItem as Classes.ClassesFornecedor.FornecedorDTO;
                Classes.ClassesPecas.PecasDTO Pdto = cboPeca.SelectedItem as Classes.ClassesPecas.PecasDTO;

                Classes.ClassesEstoque.EstoqueDTO dto = new Classes.ClassesEstoque.EstoqueDTO();
                dto.Qtd = Convert.ToString(nudQtd.Value);
                dto.PecaId = Pdto.Id;
                dto.FornecedorId = Fdto.id;

                Classes.ClassesEstoque.EstoqueBusiness business = new Classes.ClassesEstoque.EstoqueBusiness();
                business.Salvar(dto);

                MessageBox.Show("Cadastro efetuado com sucesso.", "SIGMA", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message, "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutoCarregar();
        }
    }
}
