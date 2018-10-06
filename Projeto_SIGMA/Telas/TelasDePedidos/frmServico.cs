using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_SIGMA.Classes.ClassesOrcamento;
using Projeto_SIGMA.Classes.ClassesClientes;
using Projeto_SIGMA.Classes.ClassesServico;

namespace Projeto_SIGMA.Telas.TelasDePedidos
{
    public partial class frmServico : UserControl
    {
        public frmServico()
        {
            InitializeComponent();
            CarregarCboCliente();
            CarregarCboOrcamento();
        }

        void CarregarCboCliente()
        {
            Classes.ClassesClientes.ClienteBusiness business = new Classes.ClassesClientes.ClienteBusiness();
            List<Classes.ClassesClientes.ClienteDTO> dto = business.Listar();

            cboCliente.ValueMember = nameof(Classes.ClassesClientes.ClienteDTO.Id);
            cboCliente.DisplayMember = nameof(Classes.ClassesClientes.ClienteDTO.Nome);
            cboCliente.DataSource = dto;
        }

        void CarregarCboOrcamento()
        {
            OrcamentoDTO dto = new OrcamentoDTO();
            OrcamentoBusiness buss = new OrcamentoBusiness();
            List<OrcamentoDTO> lista = buss.Listar();

            cboOrcamento.ValueMember = nameof(dto.Id);
            cboOrcamento.DisplayMember = nameof(dto.Id);
            cboOrcamento.DataSource = lista;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string desc = txtDesc.Text;
                desc = desc.Trim();
                int qtd = desc.Count();

                if (qtd > 200)
                {
                    throw new Exception("O campo 'Descrição' não pode passar de 200 caracteres");
                }


                ClienteDTO cliente = cboCliente.SelectedItem as ClienteDTO;
                OrcamentoDTO orcamento = cboOrcamento.SelectedItem as OrcamentoDTO;

                ServicoDTO dto = new ServicoDTO();
                dto.ClienteId = cliente.Id;
                dto.OrcamentoId = orcamento.Id;
                dto.Data = mkbData.Text;
                dto.Descricao = txtDesc.Text;

                ServicoBusiness buss = new ServicoBusiness();
                buss.Salvar(dto);

                MessageBox.Show("Serviço salvo com sucesso!", "SIGMA", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            frmListarPedidos tela = new frmListarPedidos();
            tela.Show();
        }
    }
}
