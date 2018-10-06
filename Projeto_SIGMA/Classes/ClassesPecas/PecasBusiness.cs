using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesPecas
{
   public class PecasBusiness
    {
        public int Salvar(PecasDTO dto)
        {
            PecasDatabase db = new PecasDatabase();

            if (dto.Nome == string.Empty)
            {
                throw new Exception("O campo 'Nome' não pode estar em branco.");
            }

            if (dto.Descricao == string.Empty)
            {
                throw new Exception("O campo 'Descricão' não pode estar em branco.");
            }

            if (dto.Valor == 0)
            {
                throw new Exception("O campo 'Valor' não pode ser zero.");
            }


            return db.Salvar(dto);
        }

        public List<PecasDTO> Listar()
        {
            PecasDatabase database = new PecasDatabase();
            return database.Listar();
        }

        public List<PecasDTO> Consultar(string nome)
        {
            PecasDatabase database = new PecasDatabase();
            return database.Consultar(nome);
        }

        public void Alterar(PecasDTO fornecedor)
        {

            PecasDatabase fornecedorDB = new PecasDatabase();
            fornecedorDB.Alterar(fornecedor);

        }

        public void Remover(int Id)
        {
            PecasDatabase db = new PecasDatabase();
            db.Remover(Id);
        }
    }
}
