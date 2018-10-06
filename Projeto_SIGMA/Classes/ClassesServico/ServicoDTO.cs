using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesServico
{
    public class ServicoDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Data { get; set; }
        public int OrcamentoId { get; set; }
        public string Descricao { get; set; }
    }
}
