using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesEstoque
{
   public class EstoqueBusiness
    {
        public int Salvar(EstoqueDTO dto)
        {
            EstoqueDatabase database = new EstoqueDatabase();

            if (dto.FornecedorId == 0)
            {
                throw new Exception("O campo 'Fornecedor' não pode estar nulo.");
            }

            if (dto.PecaId == 0)
            {
                throw new Exception("O campo 'Peça' não pode estar nulo.");
            }

            if (dto.Qtd == string.Empty && dto.Qtd == "0")
            {
                throw new Exception("O campo 'Quantidade' não pode ser zero.");
            }

            return database.Salvar(dto);
        }

        public List<EstoqueDTO> Listar()
        {
            EstoqueDatabase database = new EstoqueDatabase();
            return database.Listar();
        }

        public void Alterar(EstoqueDTO dto)
        {
            EstoqueDatabase db = new EstoqueDatabase();
            db.Alterar(dto);
        }

        public void Remover(int Id)
        {
            EstoqueDatabase db = new EstoqueDatabase();
            db.Remover(Id);
        }
    }
}
