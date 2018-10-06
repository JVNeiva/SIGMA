using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Validacoes
{
    public class ValidarUF
    {
        public bool VerificarUf(string estado)
        {
            string uf = estado.ToUpper();

            if (uf == "AC" || uf == "AL" || uf == "AP" || uf == "AM" ||
                uf == "BA" || uf == "CE" || uf == "DF" || uf == "ES" ||
                uf == "GO" || uf == "MA" || uf == "MT" || uf == "MS" ||
                uf == "MG" || uf == "PA" || uf == "PD" || uf == "PR" ||
                uf == "PE" || uf == "PI" || uf == "RJ" || uf == "RN" ||
                uf == "RS" || uf == "RO" || uf == "RR" || uf == "SC" ||
                uf == "SP" || uf == "SE" || uf == "TO")
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
