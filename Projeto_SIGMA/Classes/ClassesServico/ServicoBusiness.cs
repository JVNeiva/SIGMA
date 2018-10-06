using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesServico
{
    public class ServicoBusiness
    {
        public int Salvar(ServicoDTO dto)
        {
            ServicoDatabase db = new ServicoDatabase();
            return db.Salvar(dto);
        }

        public List<ServicoDTO> Listar()
        {
            ServicoDatabase db = new ServicoDatabase();
            return db.Listar();
        }
    }
}
