using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesOrcamento
{
    public class OrcamentoBusiness
    {
        public int Salvar(OrcamentoDTO dto)
        {
            OrcamentoDatabase db = new OrcamentoDatabase();
            return db.Salvar(dto);
        }

        public List<OrcamentoDTO> Listar()
        {
            OrcamentoDatabase db = new OrcamentoDatabase();
            return db.Listar();
        }
    }
}
