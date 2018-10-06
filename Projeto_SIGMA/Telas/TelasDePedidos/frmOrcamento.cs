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
using Projeto_SIGMA.Classes.ClassesAutomoveis;
using Projeto_SIGMA.Classes.ClassesPecas;
using Projeto_SIGMA.Classes.ClassesOrcamento;

namespace Projeto_SIGMA.Telas.TelasDePedidos
{
    public partial class frmOrcamento : UserControl
    {
        public frmOrcamento()
        {
            InitializeComponent();
            CarregarCboPeca();
            CarregarCboAutomovel();
            CarregarCboFuncionario();
        }

        void CarregarCboFuncionario()
        {
            FuncionarioDTO dto = new FuncionarioDTO();
            FuncionarioBusiness buss = new FuncionarioBusiness();
            List<FuncionarioDTO> lista = buss.Listar();

            cboFuncio.ValueMember = nameof(dto.Id);
            cboFuncio.DisplayMember = nameof(dto.Nome);
            cboFuncio.DataSource = lista;
        }

        void CarregarCboAutomovel()
        {
            AutoDTO dto = new AutoDTO();
            AutoBusiness buss = new AutoBusiness();
            List<AutoDTO> lista = buss.Listar();

            cboAuto.ValueMember = nameof(dto.Id);
            cboAuto.DisplayMember = nameof(dto.Placa);
            cboAuto.DataSource = lista;
        }

        void CarregarCboPeca()
        {
            PecasDTO dto = new PecasDTO();
            PecasBusiness buss = new PecasBusiness();
            List<PecasDTO> lista = buss.Listar();

            cboPeca.ValueMember = nameof(dto.Id);
            cboPeca.DisplayMember = nameof(dto.Nome);
            cboPeca.DataSource = lista;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string desc = txtSitua.Text;
                desc = desc.Trim();
                int qtd = desc.Count();

                if (qtd > 200)
                {
                    throw new Exception("O campo 'Situação' não pode passar de 200 caracteres");
                }

                FuncionarioDTO funcionario = cboFuncio.SelectedItem as FuncionarioDTO;
                AutoDTO auto = cboAuto.SelectedItem as AutoDTO;
                PecasDTO pecas = cboPeca.SelectedItem as PecasDTO;

                OrcamentoDTO dto = new OrcamentoDTO();
                dto.FuncionarioId = funcionario.Id;
                dto.AutoId = auto.Id;
                dto.PecaId = pecas.Id;
                dto.Situacao = txtSitua.Text;
                dto.Valor = nudValor.Value;

                OrcamentoBusiness buss = new OrcamentoBusiness();
                buss.Salvar(dto);

                MessageBox.Show("Orcamento efetuado com sucesso.", "SIGMA", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            frmListarOrcamentos tela = new frmListarOrcamentos();
            tela.Show();
        }
    }
}
