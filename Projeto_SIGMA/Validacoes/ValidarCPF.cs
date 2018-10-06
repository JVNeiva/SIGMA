using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Validacoes
{
   public class ValidarCPF
    {
        public bool VerificarCpf(String CPF)

        {
            if (CPF == "000,000,000-00" || CPF == "111,111,111-11" || CPF == "222,222,222-22" ||
                CPF == "333,333,333-33" || CPF == "444,444,444-44" || CPF == "555,555,555-55" ||
                CPF == "666,666,666-66" || CPF == "777,777,777-77" || CPF == "888,888,888-88" ||
                CPF == "999,999,999-99" || CPF == "123,456,789-10" || CPF == "121,212,121-21")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
