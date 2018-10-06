using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesOrcamento
{
    public class OrcamentoDTO
    {
        public int Id { get; set; }
        public string Situacao { get; set; }
        public int FuncionarioId { get; set; }
        public decimal Valor { get; set; } 
        public int AutoId { get; set; }
        public int PecaId { get; set; }    
    }
}
