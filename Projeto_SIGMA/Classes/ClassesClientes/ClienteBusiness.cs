using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesClientes
{
    public class ClienteBusiness
    {
        public int Salvar(ClienteDTO dto)
        {
            ClienteDatabase database = new ClienteDatabase();

            //NOME
            if (dto.Nome == string.Empty)
            {
                throw new Exception("O campo 'Nome' é obrigatório.");
            }

            //RG
            if (dto.RG == "  ,   ,   -")
            {
                throw new Exception("O campo 'RG' é obrigatório.");
            }

            //Nascimento
            if (dto.Nascimento == "  /  /")
            {
                throw new Exception("O campo 'Nascimento' é obrigatório.");
            }

            Validacoes.ValidarData data = new Validacoes.ValidarData();
            bool validData = data.validaData(dto.Nascimento);

            if (validData == false)
            {
                throw new Exception("Nascimento inválido.");
            }

            if (validData == true)
            {
                DateTime agora = DateTime.Now;
                int ano = agora.Year;
              
                
                DateTime nasc = Convert.ToDateTime(dto.Nascimento);
                int anoNasc = nasc.Year;

                string agoraTexto = Convert.ToString(agora);
                string nascTexto = Convert.ToString(nasc);

                int ResAnos = ano - anoNasc;
                
                if (ResAnos > 150)
                {
                    throw new Exception("A data informada é inválida.");
                }

                if (anoNasc > ano)
                {
                    throw new Exception("A data informada é inválida.");
                }

                if (agoraTexto == nascTexto)
                {
                    throw new Exception("A data informada é inválida.");
                }



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
            if (dto.Email == string.Empty)
            {
                throw new Exception("O campo 'E-mail' é obrigatório.");
            }
            bool ValidEmail = email.VerificarEmail(dto.Email);

            if (ValidEmail == false)
            {
                throw new Exception("Email inválido.");
            }
            
            //CIDADE
            if (dto.Cidade == string.Empty)
            {
                throw new Exception("O campo 'Cidade' é obrigatório.");
            }

            //ESTADO
            Validacoes.ValidarUF estado = new Validacoes.ValidarUF();
            if (dto.Estado == string.Empty)
            {
                throw new Exception("O campo 'Estado' é obrigatório.");
            }
            bool ValidUf = estado.VerificarUf(dto.Estado);

            if (ValidUf == false)
            {
                throw new Exception("Estado inválido.");
            }

            //BAIRRO
            if (dto.Bairro == string.Empty)
            {
                throw new Exception("O campo 'Bairro' é obrigatório.");
            }
            

            return database.Salvar(dto);
        }

        public List<ClienteDTO> Listar()
        {
            ClienteDatabase database = new ClienteDatabase();
            return database.Listar();
        }

        public List<ClienteDTO> Consultar(string nome, string cidade)
        {
            ClienteDatabase database = new ClienteDatabase();
            return database.Consultar(nome, cidade);
        }

        public void Alterar(ClienteDTO dto)
        {
            ClienteDatabase db = new ClienteDatabase();


            //NOME
            if (dto.Nome == string.Empty)
            {
                throw new Exception("O campo 'Nome' é obrigatório.");
            }

            //RG
            if (dto.RG == "  ,   ,   -")
            {
                throw new Exception("O campo 'RG' é obrigatório.");
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
            if (dto.Email == string.Empty)
            {
                throw new Exception("O campo 'E-mail' é obrigatório.");
            }
            bool ValidEmail = email.VerificarEmail(dto.Email);

            if (ValidEmail == false)
            {
                throw new Exception("Email inválido.");
            }

            //CIDADE
            if (dto.Cidade == string.Empty)
            {
                throw new Exception("O campo 'Cidade' é obrigatório.");
            }

            //ESTADO
            Validacoes.ValidarUF estado = new Validacoes.ValidarUF();
            if (dto.Estado == string.Empty)
            {
                throw new Exception("O campo 'Estado' é obrigatório.");
            }
            bool ValidUf = estado.VerificarUf(dto.Estado);

            if (ValidUf == false)
            {
                throw new Exception("Estado inválido.");
            }

            //BAIRRO
            if (dto.Bairro == string.Empty)
            {
                throw new Exception("O campo 'Bairro' é obrigatório.");
            }


            db.Alterar(dto);
        }

        public void Remover(int Id)
        {
            ClienteDatabase db = new ClienteDatabase();
            db.Remover(Id);
        }

    }
}
