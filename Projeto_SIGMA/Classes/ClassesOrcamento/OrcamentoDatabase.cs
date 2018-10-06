using MySql.Data.MySqlClient;
using Projeto_SIGMA.Classes.ClassesConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesOrcamento
{
    public class OrcamentoDatabase
    {
        public int Salvar(OrcamentoDTO dto)
        {
            string script = @"INSERT INTO tb_orcamento(
                            id_orcamento, 
                            ds_situacao,
                            id_funcionario,
                            vl_valor,
                            id_automovel,
                            id_pecas) VALUES(
                            @id_orcamento, 
                            @ds_situacao,
                            @id_funcionario,
                            @vl_valor,
                            @id_automovel,
                            @id_pecas)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("ds_situacao", dto.Situacao));
            parms.Add(new MySqlParameter("id_funcionario", dto.FuncionarioId));
            parms.Add(new MySqlParameter("vl_valor", dto.Valor));
            parms.Add(new MySqlParameter("id_automovel", dto.AutoId));
            parms.Add(new MySqlParameter("id_pecas", dto.PecaId));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);

        }

        public List<OrcamentoDTO> Listar()
        {
            string script = @"SELECT * FROM tb_orcamento";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<OrcamentoDTO> lista = new List<OrcamentoDTO>();
            while (reader.Read())
            {
                OrcamentoDTO dto = new OrcamentoDTO();
                dto.Id = reader.GetInt32("id_orcamento");
                dto.Situacao = reader.GetString("ds_situacao");
                dto.FuncionarioId = reader.GetInt32("id_funcionario");
                dto.Valor = reader.GetDecimal("vl_valor");
                dto.AutoId = reader.GetInt32("id_automovel");
                dto.PecaId = reader.GetInt32("id_pecas");

                lista.Add(dto);
            }
            reader.Close();
            return lista;
        }

    }
}
