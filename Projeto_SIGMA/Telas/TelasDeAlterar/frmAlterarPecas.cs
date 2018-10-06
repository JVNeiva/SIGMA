using Projeto_SIGMA.Classes.ClassesPecas;
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
    public partial class frmAlterarPecas : Form
    {
        public frmAlterarPecas()
        {
            InitializeComponent();
        }

        PecasDTO dto;

        public void LoadScreen(PecasDTO dto)
        {
            this.dto = dto;
            txtNome.Text = dto.Nome;
            txtDesc.Text = dto.Descricao;
            nudPreco.Value = dto.Valor;
        }

        private void frmAlterarPecas_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                nome = nome.Trim();
                int qdtNome = nome.Count();

                if (qdtNome > 45)
                {
                    throw new Exception("O campo 'Nome' não pode conter mais de 45 caracteres.");
                }
                else if (qdtNome == 0)
                {
                    throw new Exception("Nome inválido.");
                }

                string desc = txtDesc.Text;
                desc = desc.Trim();
                int qtdDesc = desc.Count();

                if (qtdDesc > 300)
                {
                    throw new Exception("O campo 'Descrição' não pode ter mais de 300 caracteres.");
                }
                else if (qtdDesc == 0)
                {
                    throw new Exception("Descrição imválida.");
                }

                dto.Nome = txtNome.Text;
                dto.Descricao = txtDesc.Text;
                dto.Valor = nudPreco.Value;

                Classes.ClassesPecas.PecasBusiness business = new Classes.ClassesPecas.PecasBusiness();
                business.Alterar(dto);

                MessageBox.Show("Peça alterada com sucesso!", "SIGMA", MessageBoxButtons.OK);

                frmListarPecas tela = new frmListarPecas();
                tela.AutoCarregar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
