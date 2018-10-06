using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesAutomoveis
{
    public class AutoBusiness
    {
        public int Salvar(AutoDTO dto)
        {
            AutoDatabase database = new AutoDatabase();

            if (dto.ClienteId == 0)
            {
                throw new Exception("O campo 'Id do cliente' é obrigatório."); 
            }

            if (dto.Marca == string.Empty)
            {
                throw new Exception("O campo 'Marca' é obrigatório.");
            }

            if (dto.Modelo == string.Empty)
            {
                throw new Exception("O campo 'Modelo' é obrigatório.");
            }

            if (dto.Placa == "   -")
            {
                throw new Exception("O campo 'Placa' é obrigatório");
            }

            return database.Salvar(dto);
        }

        public List<AutoDTO> Listar()
        {
            AutoDatabase database = new AutoDatabase();
            return database.Listar();
        }

        public List<AutoDTO> Consultar(string marca, string placa, string modelo)
        {
            AutoDatabase database = new AutoDatabase();
            return database.Consultar(marca, placa, modelo);
        }

        public void Alterar(AutoDTO dto)
        {
            AutoDatabase db = new AutoDatabase();

            if (dto.ClienteId == 0)
            {
                throw new Exception("O campo 'Id do cliente' é obrigatório.");
            }

            if (dto.Marca == string.Empty)
            {
                throw new Exception("O campo 'Marca' é obrigatório.");
            }

            if (dto.Modelo == string.Empty)
            {
                throw new Exception("O campo 'Modelo' é obrigatório.");
            }

            if (dto.Placa == "   -")
            {
                throw new Exception("O campo 'Placa' é obrigatório");
            }


            db.Alterar(dto);
        }

        public void Remover(int AutoId)
        {
            AutoDatabase db = new AutoDatabase();
            db.Remover(AutoId);
        }
    }
}
