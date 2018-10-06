using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesLogin
{
    public class LoginBusiness
    {
        public int Salvar(LoginDTO dto)
        {
            if (dto.Usuario == string.Empty)
            {
                throw new Exception("O nome de usuário é obrigatório.");
            }

            if (dto.Senha == string.Empty)
            {
                throw new Exception("A senha é obrigatória.");
            }

            if (dto.Nome == string.Empty)
            {
                throw new Exception("O nome é obrigatório.");
            }


            if (dto.Email == string.Empty)
            {
                throw new Exception("O E-mail é obrigatório.");
            }

            Validacoes.ValidarEmail email = new Validacoes.ValidarEmail();
            bool validEmail = email.VerificarEmail(dto.Email);

            if (validEmail == false)
            {
                throw new Exception("Email inválido");
            }

            if (dto.PermissaoAdm == false && dto.PermissaoCadastro == false && dto.PermissaoConsulta == false
                && dto.PermissaoOrcamento == false && dto.PermissaoPedido == false)
            {
                throw new Exception("Pelo menos uma permissão o usuário deve possuir.");
            }



            LoginDatabase database = new LoginDatabase();
            return database.Salvar(dto);
        }

        public LoginDTO Logar(string usuario, string senha)
        {
            LoginDatabase database = new LoginDatabase();
            return database.Logar(usuario, senha);
        }
    }
}
