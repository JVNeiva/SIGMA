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
using MySql.Data.MySqlClient;

namespace Projeto_SIGMA.Telas
{
    public partial class frmCadastrarAutomovel : UserControl
    {
        public frmCadastrarAutomovel()
        {
            InitializeComponent();
            CarregarCombos();
            AutoCarregar();
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
          
            try
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


                Classes.ClassesClientes.ClienteDTO dto = cboCliente.SelectedItem as Classes.ClassesClientes.ClienteDTO;

                Classes.ClassesAutomoveis.AutoDTO autoDTO = new Classes.ClassesAutomoveis.AutoDTO();
                autoDTO.ClienteId = dto.Id;
                autoDTO.Marca = txtMarca.Text;
                autoDTO.Modelo = txtModelo.Text;
                autoDTO.Placa = txtPlaca.Text;

                Classes.ClassesAutomoveis.AutoBusiness business = new Classes.ClassesAutomoveis.AutoBusiness();
                business.Salvar(autoDTO);

                MessageBox.Show("Automóvel salvo com sucesso!", "SIGMA", MessageBoxButtons.OK);
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvListarCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                cboCliente.Text = dgvListarCliente[1, dgvListarCliente.CurrentRow.Index].Value.ToString();
            }
        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmCadastrarAutomovel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsWhiteSpace(e.KeyChar) == true || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
