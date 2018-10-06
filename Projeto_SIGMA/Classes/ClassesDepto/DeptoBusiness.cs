using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesDepto
{
    public class DeptoBusiness
    {
        public int Salvar(DeptoDTO dto)
        {
            DeptoDatabase database = new DeptoDatabase();

            if (dto.Departamento == string.Empty)
            {
                throw new Exception("O campo 'Nome do Departamento' é obrigatório.");
            }

            return database.Salvar(dto);
        }

        public List<DeptoDTO> Listar()
        {
            DeptoDatabase database = new DeptoDatabase();
            return database.Listar();
        }

        public List<DeptoDTO> Consultar(string depto)
        {
            DeptoDatabase database = new DeptoDatabase();
            return database.Consultar(depto);
        }

        public void Alterar(DeptoDTO dto)
        {
            DeptoDatabase db = new DeptoDatabase();
            db.Alterar(dto);
        }

        public void Remover(int Id)
        {
            DeptoDatabase db = new DeptoDatabase();
            db.Remover(Id);
        }
    }
}
