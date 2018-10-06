using MySql.Data.MySqlClient;
using Projeto_SIGMA.Classes.ClassesConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesFornecedor
{

    public class FornecedorDatabase
    {

        public int Salvar(FornecedorDTO fornecedor)
        {

            string script =
             @"INSERT INTO tb_fornecedores(nm_fornecedor, ds_cpf_cnpj, nm_cidade,  nm_estado )
                    VALUES (@nm_fornecedor, @ds_cpf_cnpj, @nm_cidade,  @nm_estado )";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_fornecedor", fornecedor.Nome));
            parms.Add(new MySqlParameter("ds_cpf_cnpj", fornecedor.Discricao));
            parms.Add(new MySqlParameter("nm_cidade", fornecedor.Cidade));
            parms.Add(new MySqlParameter("nm_estado", fornecedor.Estado));

            Database db = new Database();
            int pk = db.ExecuteInsertScriptWithPk(script, parms);
            return pk;
        }

        public void Alterar(FornecedorDTO fornecedor)
        {

            string script =
                  @"UPDATE tb_fornecedores SET nm_fornecedor = @nm_fornecedor,
                                               ds_cpf_cnpj = @ds_cpf_cnpj,
                                               nm_cidade = @nm_cidade,
                                               nm_estado = @nm_estado  WHERE 
                                               id_fornecedor = @id_fornecedor";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_fornecedor", fornecedor.id));
            parms.Add(new MySqlParameter("nm_fornecedor", fornecedor.Nome));
            parms.Add(new MySqlParameter("ds_cpf_cnpj", fornecedor.Discricao));
            parms.Add(new MySqlParameter("nm_cidade", fornecedor.Cidade));
            parms.Add(new MySqlParameter("nm_estado", fornecedor.Estado));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public void Remover(int Id)
        {
            string script = @"DELETE FROM tb_fornecedores WHERE id_fornecedor = @id_fornecedor";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_fornecedor", Id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public List<FornecedorDTO> Listar()
        {

            string script =
                @"SELECT * FROM tb_fornecedores";

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, null);

            List<FornecedorDTO> fornecedores = new List<FornecedorDTO>();
            while (reader.Read())
            {

                FornecedorDTO fornecedor = new FornecedorDTO();
                fornecedor.id = reader.GetInt32("id_fornecedor");
                fornecedor.Nome = reader.GetString("nm_fornecedor");
                fornecedor.Discricao = reader.GetString("ds_cpf_cnpj");
                fornecedor.Cidade = reader.GetString("nm_cidade");
                fornecedor.Estado = reader.GetString("nm_estado");

                fornecedores.Add(fornecedor);
            }

            reader.Close();

            return fornecedores;

        }

        public List<FornecedorDTO> Consultar(string nome)
        {
            string script = @"SELECT * FROM tb_fornecedores WHERE nm_fornecedor LIKE @nm_fornecedor";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_fornecedor", nome + "%"));


            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);
            List<FornecedorDTO> lista = new List<FornecedorDTO>();

            while (reader.Read())
            {
                FornecedorDTO fornecedor = new FornecedorDTO();
                fornecedor.id = reader.GetInt32("id_fornecedor");
                fornecedor.Nome = reader.GetString("nm_fornecedor");
                fornecedor.Discricao = reader.GetString("ds_cpf_cnpj");
                fornecedor.Cidade = reader.GetString("nm_cidade");
                fornecedor.Estado = reader.GetString("nm_estado");


                lista.Add(fornecedor);
            }
            reader.Close();

            return lista;

        }

    }
}
