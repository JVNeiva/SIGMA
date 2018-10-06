using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesLogin
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool PermissaoAdm { get; set; }
        public bool PermissaoCadastro { get; set; }
        public bool PermissaoConsulta { get; set; }
        public bool PermissaoOrcamento { get; set; }
        public bool PermissaoPedido { get; set; }

    }
}
