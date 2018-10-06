using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_SIGMA.Telas
{
    public partial class frmCadastrarPecas : UserControl
    {
        public frmCadastrarPecas()
        {
            InitializeComponent();
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

                Classes.ClassesPecas.PecasDTO dto = new Classes.ClassesPecas.PecasDTO();
                dto.Nome = txtNome.Text;
                dto.Descricao = txtDesc.Text;
                dto.Valor = nudPreco.Value;

                Classes.ClassesPecas.PecasBusiness business = new Classes.ClassesPecas.PecasBusiness();
                business.Salvar(dto);

                MessageBox.Show("Peça cadastrada com sucesso!", "SIGMA", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }
    }
}
