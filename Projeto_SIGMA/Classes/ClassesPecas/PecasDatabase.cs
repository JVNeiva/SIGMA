using MySql.Data.MySqlClient;
using Projeto_SIGMA.Classes.ClassesConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesPecas
{
    public class PecasDatabase
    {
        public int Salvar(PecasDTO dto)
        {
            string script = @"INSERT INTO tb_pecas(
                    nm_peca,
                    ds_peca,
                    vl_peca) VALUES(
                    @nm_peca,
                    @ds_peca,
                    @vl_peca)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_peca", dto.Nome));
            parms.Add(new MySqlParameter("ds_peca", dto.Descricao));
            parms.Add(new MySqlParameter("vl_peca", dto.Valor));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }

        public List<PecasDTO> Listar()
        {
            string script = @"SELECT * FROM tb_pecas";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            Database db = new Database();

            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);
            List<PecasDTO> lista = new List<PecasDTO>();

            while (reader.Read())
            {
                PecasDTO dto = new PecasDTO();
                dto.Id = reader.GetInt32("id_pecas");
                dto.Nome = reader.GetString("nm_peca");
                dto.Descricao = reader.GetString("ds_peca");
                dto.Valor = reader.GetDecimal("vl_peca");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public List<PecasDTO> Consultar(string nome)
        {
            string script = @"SELECT * FROM tb_pecas WHERE nm_peca LIKE @nm_peca";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_peca", nome + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<PecasDTO> lista = new List<PecasDTO>();
            while (reader.Read())
            {
                PecasDTO dto = new PecasDTO();
                dto.Id = reader.GetInt32("id_pecas");
                dto.Nome = reader.GetString("nm_peca");
                dto.Descricao = reader.GetString("ds_peca");
                dto.Valor = reader.GetDecimal("vl_peca");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public void Alterar(PecasDTO dto)
        {
            string script = @"UPDATE tb_pecas SET
                    nm_peca = @nm_peca,
                    ds_peca = @ds_peca,
                    vl_peca = @vl_peca WHERE
                    id_pecas = @id_pecas";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_pecas", dto.Id));
            parms.Add(new MySqlParameter("nm_peca", dto.Nome));
            parms.Add(new MySqlParameter("ds_peca", dto.Descricao));
            parms.Add(new MySqlParameter("vl_peca", dto.Valor));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public void Remover(int Id)
        {
            string script = @"DELETE FROM tb_pecas WHERE id_pecas = @id_pecas";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_pecas", Id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
    }
}
