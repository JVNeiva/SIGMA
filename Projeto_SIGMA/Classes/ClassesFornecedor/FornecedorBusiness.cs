using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesFornecedor
{
    public class FornecedorBusiness
    {

        public int Salvar (FornecedorDTO dto)
        {

            FornecedorDatabase FornecedorDB = new FornecedorDatabase();

            if (dto.Nome == string.Empty)
            {
                throw new Exception("O campo 'Nome' é obrigatório.");
            }

            if (dto.Cidade == string.Empty)
            {
                throw new Exception("O campo 'Cidade' é obrigatório.");
            }

            //ESTADO
            Validacoes.ValidarUF uf = new Validacoes.ValidarUF();
            bool validarUF = uf.VerificarUf(dto.Estado);
            if (dto.Estado == string.Empty)
            {
                throw new Exception("O campo 'Estado' é obrigatório.");
            }

            if (validarUF == false)
            {
                throw new Exception("Estado inválido.");
            }


            if (dto.Discricao == "  ,   ,   /    -")
            {
                throw new Exception("O campo 'CNPJ' é obrigatório.");
            }

            Validacoes.ValidarCPF_CNPJ cnpj = new Validacoes.ValidarCPF_CNPJ();
            bool ValidCNPJ = cnpj.VerificaCpfCnpj(dto.Discricao);

            if (ValidCNPJ == false)
            {
                throw new Exception("CNPJ inválido.");
            }

            int id = FornecedorDB.Salvar(dto);
            return id;

        }

        public void Alterar(FornecedorDTO dto)
        {

            FornecedorDatabase fornecedorDB = new FornecedorDatabase();

            if (dto.Nome == string.Empty)
            {
                throw new Exception("O campo 'Nome' é obrigatório.");
            }

            if (dto.Cidade == string.Empty)
            {
                throw new Exception("O campo 'Cidade' é obrigatório.");
            }

            //ESTADO
            Validacoes.ValidarUF uf = new Validacoes.ValidarUF();
            bool validarUF = uf.VerificarUf(dto.Estado);
            if (dto.Estado == string.Empty)
            {
                throw new Exception("O campo 'Estado' é obrigatório.");
            }

            if (validarUF == false)
            {
                throw new Exception("Estado inválido.");
            }


            if (dto.Discricao == "  ,   ,   /    -")
            {
                throw new Exception("O campo 'CNPJ' é obrigatório.");
            }


            fornecedorDB.Alterar(dto);

        }

        public void Remover(int Id)
        {
            FornecedorDatabase db = new FornecedorDatabase();
            db.Remover(Id);
        }

        public List<FornecedorDTO> Listar()
        {

            FornecedorDatabase fornecedorDB = new FornecedorDatabase ();
            List<FornecedorDTO> Fornecedor = fornecedorDB.Listar();
            return Fornecedor;

        }

        public List<FornecedorDTO> Consultar(string nome)
        {
            FornecedorDatabase database = new FornecedorDatabase();
            return database.Consultar(nome);
        }

    }

}
