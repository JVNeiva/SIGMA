using MySql.Data.MySqlClient;
using Projeto_SIGMA.Classes.ClassesAutomoveis;
using Projeto_SIGMA.Classes.ClassesClientes;
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
    public partial class frmAlterarAutomovel : Form
    {
        public frmAlterarAutomovel()
        {
            InitializeComponent();
            AutoCarregar();
            CarregarCombos();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        AutoDTO dto;

        public void LoadScreen(AutoDTO dto)
        {
            this.dto = dto;
            txtPlaca.Text = dto.Placa;
            txtMarca.Text = dto.Marca;
            txtModelo.Text = dto.Modelo;
            cboCliente.SelectedItem = dto.ClienteId;
        }

        void CarregarCombos()
        {
            Classes.ClassesClientes.ClienteBusiness business = new Classes.ClassesClientes.ClienteBusiness();
            List<Classes.ClassesClientes.ClienteDTO> dto = business.Listar();

            cboCliente.ValueMember = nameof(Classes.ClassesClientes.ClienteDTO.Id);
            cboCliente.DisplayMember = nameof(Classes.ClassesClientes.ClienteDTO.Nome);
            cboCliente.DataSource = dto;
        }

        public void CarregarGrid()
        {
            string nome = txtBuscar.Text;
            string a = string.Empty;

            Classes.ClassesClientes.ClienteBusiness business = new Classes.ClassesClientes.ClienteBusiness();
            List<Classes.ClassesClientes.ClienteDTO> dto = business.Consultar(nome, a);

            dgvListarCliente.AutoGenerateColumns = false;
            dgvListarCliente.DataSource = dto;
        }

        public void AutoCarregar()
        {
            Classes.ClassesClientes.ClienteBusiness business = new Classes.ClassesClientes.ClienteBusiness();
            List<Classes.ClassesClientes.ClienteDTO> dto = business.Listar();

            dgvListarCliente.AutoGenerateColumns = false;
            dgvListarCliente.DataSource = dto;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string marca = txtMarca.Text;
            marca = marca.Trim();
            int qtdMarca = marca.Count();

            if (qtdMarca > 45)
            {
                throw new Exception("Marca não pode passar de 45 caracteres.");
            }
            if (qtdMarca == 0)
            {
                throw new Exception("Marca inválida.");
            }

            string modelo = txtModelo.Text;
            modelo = modelo.Trim();
            int qtdModelo = modelo.Count();
            if (qtdModelo > 45)
            {
                throw new Exception("Modelo não pode passar de 45 caracteres.");

            }
            if (qtdModelo == 0)
            {
                throw new Exception("Modelo inválido.");
            }
            try
            {
                

                Classes.ClassesClientes.ClienteDTO cliente = cboCliente.SelectedItem as Classes.ClassesClientes.ClienteDTO;
                
                dto.ClienteId = cliente.Id;
                dto.Marca = txtMarca.Text;
                dto.Modelo = txtModelo.Text;
                dto.Placa = txtPlaca.Text;

                Classes.ClassesAutomoveis.AutoBusiness business = new Classes.ClassesAutomoveis.AutoBusiness();
                business.Alterar(dto);

                MessageBox.Show("Automóvel alterado com sucesso!", "SIGMA", MessageBoxButtons.OK);

                frmListarAutomoveis tela = new frmListarAutomoveis();
                tela.AutoCarregar();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Placa já existente.", "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void dgvListarCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                ClienteDTO dto = dgvListarCliente.Rows[e.RowIndex].DataBoundItem as ClienteDTO;

                cboCliente.ValueMember = nameof(dto.Id);
                cboCliente.DisplayMember = nameof(dto.Nome);

            }
        }
    }
}
