using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Validacoes
{
    public class ValidarCNPJ
    {
        public bool VerificaCNPJ(String cpf)

        {
            if (Regex.IsMatch(cpf, @"^((\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2}))*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
