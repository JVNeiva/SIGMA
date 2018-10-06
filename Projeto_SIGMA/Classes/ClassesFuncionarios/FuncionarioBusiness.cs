using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesFuncionarios
{
    public class FuncionarioBusiness
    {
        public int Salvar(FuncionarioDTO dto)
        {
            FuncionarioDatabase database = new FuncionarioDatabase();

            if (dto.Nome == string.Empty)
            {
                throw new Exception("O campo 'Nome' é obrigatório.");
            }

            //RG
            if (dto.RG == "  ,   ,   -")
            {
                throw new Exception("O campo 'CPF' é obrigatório.");
            }

            //Nascimento
            if (dto.Nascimento == "  /  /")
            {
                throw new Exception("O campo 'Nascimento' é obrigatório.");
            }

            //CPF
            if (dto.CPF == "   ,   ,   -")
            {
                throw new Exception("O campo 'CPF' é obrigatório.");
            }

            Validacoes.ValidarCPF cpf = new Validacoes.ValidarCPF();
            bool validouCpf = cpf.VerificarCpf(dto.CPF);

            if (validouCpf == false)
            {
                throw new Exception("CPF inválido.");
            }


            //TELEFONE
            Validacoes.ValidarTelefone telefone = new Validacoes.ValidarTelefone();

            if (dto.Telefone == string.Empty)
            {
                throw new Exception("O campo 'Telefone' é obrigatório.");
            }
            bool validTell = telefone.VerificarTelefone(dto.Telefone);

            if (validTell == false)
            {
                throw new Exception("Telefone inválido.");
            }


            //EMAIL
            Validacoes.ValidarEmail email = new Validacoes.ValidarEmail();
            bool valiemail = email.VerificarEmail(dto.Email);

            if (dto.Email == string.Empty)
            {
                throw new Exception("O campo 'E-mail' é obrigatório.");
            }

            if (valiemail == false)
            {               
                throw new Exception("Email inválido.");               
            }


            if (dto.Cidade == string.Empty)
            {
                throw new Exception("O campo 'Cidade' é obrigatório.");
            }

            //ESTADO
            Validacoes.ValidarUF uf = new Validacoes.ValidarUF();
            bool validar = uf.VerificarUf(dto.Estado);

            if (dto.Estado == string.Empty)
            {
                throw new Exception("O campo 'Estado' é obrigatório.");
            }

            if (validar == false)
            {
                throw new Exception("Cidade inválida.");
            }


            if (dto.Bairro == string.Empty)
            {
                throw new Exception("O campo 'Bairro' é obrigatório.");
            }

            if (dto.Rua == string.Empty)
            {
                throw new Exception("O campo 'Rua' é obrigatório.");
            }


            //CEP
            if (dto.CEP == "     -")
            {
                throw new Exception("O campo 'CEP' é obrigatório.");
            }

            return database.Salvar(dto);
        }

        public List<FuncionarioDTO> Listar()
        {
            FuncionarioDatabase db = new FuncionarioDatabase();
            return db.Listar();
        }

        public List<FuncionarioDTO> Consultar(string nome, string cidade)
        {
            FuncionarioDatabase db = new FuncionarioDatabase();
            return db.Consultar(nome, cidade);
        }

        public void Alterar(FuncionarioDTO dto)
        {

            FuncionarioDatabase fornecedorDB = new FuncionarioDatabase();

            if (dto.Nome == string.Empty)
            {
                throw new Exception("O campo 'Nome' é obrigatório.");
            }

            //RG
            if (dto.RG == "  ,   ,   -")
            {
                throw new Exception("O campo 'CPF' é obrigatório.");
            }

            //Nascimento
            if (dto.Nascimento == "  /  /")
            {
                throw new Exception("O campo 'Nascimento' é obrigatório.");
            }

            //CPF
            if (dto.CPF == "   ,   ,   -")
            {
                throw new Exception("O campo 'CPF' é obrigatório.");
            }

            if (dto.CPF == "000,000,000-00" || dto.CPF == "111,111,111-11" || dto.CPF == "222,222,222-22" ||
                dto.CPF == "333,333,333-33" || dto.CPF == "444,444,444-44" || dto.CPF == "555,555,555-55" ||
                dto.CPF == "666,666,666-66" || dto.CPF == "777,777,777-77" || dto.CPF == "888,888,888-88" ||
                dto.CPF == "999,999,999-99" || dto.CPF == "123,456,789-10" || dto.CPF == "121,212,121-21")
            {
                throw new Exception("CPF Inválido.");
            }

            //TELEFONE
            Validacoes.ValidarTelefone telefone = new Validacoes.ValidarTelefone();

            if (dto.Telefone == string.Empty)
            {
                throw new Exception("O campo 'Telefone' é obrigatório.");
            }
            bool validTell = telefone.VerificarTelefone(dto.Telefone);

            if (validTell == false)
            {
                throw new Exception("Telefone inválido.");
            }


            //EMAIL
            Validacoes.ValidarEmail email = new Validacoes.ValidarEmail();
            bool valiemail = email.VerificarEmail(dto.Email);

            if (dto.Email == string.Empty)
            {
                throw new Exception("O campo 'E-mail' é obrigatório.");
            }

            if (valiemail == false)
            {
                throw new Exception("Email inválido.");
            }


            if (dto.Cidade == string.Empty)
            {
                throw new Exception("O campo 'Cidade' é obrigatório.");
            }

            //ESTADO
            Validacoes.ValidarUF uf = new Validacoes.ValidarUF();
            bool validar = uf.VerificarUf(dto.Estado);

            if (dto.Estado == string.Empty)
            {
                throw new Exception("O campo 'Estado' é obrigatório.");
            }

            if (validar == false)
            {
                throw new Exception("Cidade inválida.");
            }


            if (dto.Bairro == string.Empty)
            {
                throw new Exception("O campo 'Bairro' é obrigatório.");
            }

            if (dto.Rua == string.Empty)
            {
                throw new Exception("O campo 'Rua' é obrigatório.");
            }


            //CEP
            if (dto.CEP == "     -")
            {
                throw new Exception("O campo 'CEP' é obrigatório.");
            }

            fornecedorDB.Alterar(dto);

        }

        public void Remover(int Id)
        {
            FuncionarioDatabase db = new FuncionarioDatabase();
            db.Remover(Id);
        }
    }
}
