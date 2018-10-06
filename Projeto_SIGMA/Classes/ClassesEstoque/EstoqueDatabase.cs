using MySql.Data.MySqlClient;
using Projeto_SIGMA.Classes.ClassesConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesEstoque
{
    public class EstoqueDatabase
    {
        public int Salvar(EstoqueDTO dto)
        {
            string script = @"INSERT INTO tb_estoque(
                    id_peca,
                    id_fornecedor,
                    nr_quantidade) VALUES(
                    @id_peca,
                    @id_fornecedor,
                    @nr_quantidade)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_peca", dto.PecaId));
            parms.Add(new MySqlParameter("id_fornecedor", dto.FornecedorId));
            parms.Add(new MySqlParameter("nr_quantidade", dto.Qtd));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);

        }

        public List<EstoqueDTO> Listar()
        {
            string script = @"SELECT * FROM tb_estoque";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<EstoqueDTO> lista = new List<EstoqueDTO>();
            while (reader.Read())
            {
                EstoqueDTO dto = new EstoqueDTO();
                dto.Id = reader.GetInt32("id_estoque");
                dto.PecaId = reader.GetInt32("id_peca");
                dto.FornecedorId = reader.GetInt32("id_fornecedor");
                dto.Qtd = reader.GetString("nr_quantidade");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public void Alterar(EstoqueDTO dto)
        {
            string script = @"UPDATE tb_estoque SET 
                    id_peca = @id_peca,
                    id_fornecedor = @id_fornecedor,
                    nr_quantidade = @nr_quantidade WHERE
                    id_estoque = @id_estoque";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_estoque", dto.Id));
            parms.Add(new MySqlParameter("id_peca", dto.PecaId));
            parms.Add(new MySqlParameter("id_fornecedor", dto.FornecedorId));
            parms.Add(new MySqlParameter("nr_quantidade", dto.Qtd));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public void Remover(int Id)
        {
            string script = @"DELETE FROM tb_estoque WHERE id_estoque = @id_estoque";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_estoque", Id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
    }
}
