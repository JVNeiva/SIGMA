using MySql.Data.MySqlClient;
using Projeto_SIGMA.Classes.ClassesConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesServico
{
    public class ServicoDatabase
    {
        public int Salvar(ServicoDTO dto)
        {
            string script = @"INSERT INTO tb_servico(
                            id_cliente,
                            dt_servico,
                            id_orcamento,
                            ds_servico) VALUES(
                            @id_cliente,
                            @dt_servico,
                            @id_orcamento,
                            @ds_servico)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_cliente", dto.ClienteId));
            parms.Add(new MySqlParameter("dt_servico", dto.Data));
            parms.Add(new MySqlParameter("id_orcamento", dto.OrcamentoId));
            parms.Add(new MySqlParameter("ds_servico", dto.Descricao));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);

        }

        public List<ServicoDTO> Listar()
        {
            string script = @"SELECT * FROM tb_servico";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<ServicoDTO> lista = new List<ServicoDTO>();
            while (reader.Read())
            {
                ServicoDTO dto = new ServicoDTO();
                dto.Id = reader.GetInt32("id_servico");
                dto.ClienteId = reader.GetInt32("id_cliente");
                dto.Data = reader.GetString("dt_servico");
                dto.OrcamentoId = reader.GetInt32("id_orcamento");
                dto.Descricao = reader.GetString("ds_servico");

                lista.Add(dto);
            }
            reader.Close();
            return lista;
        }
    }
}
