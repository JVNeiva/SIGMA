using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesEstoque
{
    public class EstoqueDTO
    {
        public int Id { get; set; }
        public int FornecedorId { get; set; }
        public int PecaId { get; set; }
        public string Qtd { get; set; }
    }
}
