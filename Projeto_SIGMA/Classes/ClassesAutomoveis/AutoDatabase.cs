using MySql.Data.MySqlClient;
using Projeto_SIGMA.Classes.ClassesConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesAutomoveis
{
    public class AutoDatabase
    {
        public int Salvar(AutoDTO dto)
        {
            string script = @"INSERT INTO tb_automoveis(
                    id_cliente,
                    ds_placa,
                    nm_marca,
                    nm_modelo) VALUES(
                    @id_cliente,
                    @ds_placa,
                    @nm_marca,
                    @nm_modelo)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_cliente", dto.ClienteId));
            parms.Add(new MySqlParameter("ds_placa", dto.Placa));
            parms.Add(new MySqlParameter("nm_marca", dto.Marca));
            parms.Add(new MySqlParameter("nm_modelo", dto.Modelo));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }

        public List<AutoDTO> Listar()
        {
            string script = @"SELECT * FROM tb_automoveis";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<AutoDTO> lista = new List<AutoDTO>();
            while (reader.Read())
            {
                AutoDTO dto = new AutoDTO();
                dto.Id = reader.GetInt32("id_automoveis");
                dto.ClienteId = reader.GetInt32("id_cliente");
                dto.Placa = reader.GetString("ds_placa");
                dto.Marca = reader.GetString("nm_marca");
                dto.Modelo = reader.GetString("nm_modelo");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public List<AutoDTO> Consultar(string marca, string placa, string modelo)
        {
            string script = @"SELECT * FROM tb_automoveis WHERE
                    nm_marca LIKE @nm_marca AND ds_placa LIKE @ds_placa AND nm_modelo LIKE @nm_modelo";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_marca", marca + "%"));
            parms.Add(new MySqlParameter("ds_placa", placa + "%"));
            parms.Add(new MySqlParameter("nm_modelo", modelo + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<AutoDTO> lista = new List<AutoDTO>();
            while (reader.Read())
            {
                AutoDTO dto = new AutoDTO();
                dto.Id = reader.GetInt32("id_automoveis");
                dto.ClienteId = reader.GetInt32("id_cliente");
                dto.Placa = reader.GetString("ds_placa");
                dto.Marca = reader.GetString("nm_marca");
                dto.Modelo = reader.GetString("nm_modelo");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public void Alterar(AutoDTO dto)
        {
            string script = @"UPDATE tb_automoveis SET
                    id_cliente = @id_cliente,
                    ds_placa = @ds_placa,
                    nm_marca = @nm_marca,
                    nm_modelo = @nm_modelo WHERE
                    id_automoveis = @id_automoveis";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_automoveis", dto.Id));
            parms.Add(new MySqlParameter("id_cliente", dto.ClienteId));
            parms.Add(new MySqlParameter("ds_placa", dto.Placa));
            parms.Add(new MySqlParameter("nm_marca", dto.Marca));
            parms.Add(new MySqlParameter("nm_modelo", dto.Modelo));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public void Remover(int AutoId)
        {
            string script = @"DELETE FROM tb_automoveis WHERE id_automoveis = @id_automoveis";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_automoveis", AutoId));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
    }
}
