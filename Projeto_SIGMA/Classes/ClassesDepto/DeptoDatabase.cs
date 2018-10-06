using MySql.Data.MySqlClient;
using Projeto_SIGMA.Classes.ClassesConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesDepto
{
    public class DeptoDatabase
    {
        public int Salvar(DeptoDTO dto)
        {
            string script = @"INSERT INTO tb_depto(nm_depto) VALUES(@nm_depto)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_depto", dto.Departamento));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }

        public List<DeptoDTO> Listar()
        {
            string script = @"SELECT * FROM tb_depto";

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, null);

            List<DeptoDTO> deptos = new List<DeptoDTO>();
            while (reader.Read())
            {
                DeptoDTO dto = new DeptoDTO();
                dto.Id = reader.GetInt32("id_depto");
                dto.Departamento = reader.GetString("nm_depto");
                deptos.Add(dto);
            }
            reader.Close();
            return deptos;
        }

        public List<DeptoDTO> Consultar(string depto)
        {
            string script = @"SELECT * FROM tb_depto WHERE nm_depto LIKE @nm_depto";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_depto", depto + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<DeptoDTO> lista = new List<DeptoDTO>();
            while (reader.Read())
            {
                DeptoDTO dto = new DeptoDTO();
                dto.Id = reader.GetInt32("id_depto");
                dto.Departamento = reader.GetString("nm_depto");
                lista.Add(dto);
            }
            reader.Close();
            return lista;
        }

        public void Alterar(DeptoDTO dto)
        {
            string script = @"UPDATE tb_depto SET nm_depto = @nm_depto WHERE id_depto = @id_depto";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_depto", dto.Id));
            parms.Add(new MySqlParameter("nm_depto", dto.Departamento));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public void Remover(int Id)
        {
            string script = @"DELETE FROM tb_depto WHERE id_depto = @id_depto";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_depto", Id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
    }
}
