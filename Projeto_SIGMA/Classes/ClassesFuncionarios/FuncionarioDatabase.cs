using MySql.Data.MySqlClient;
using Projeto_SIGMA.Classes.ClassesConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesFuncionarios
{
    public class FuncionarioDatabase
    {
        public int Salvar(FuncionarioDTO dto)
        {
            string script = @"INSERT INTO tb_funcionario(
                            nm_funcionario,
                            dt_nascimento,
                            ds_rg,
                            ds_cpf, 
                            ds_telefone,
                            ds_email,
                            id_depto,
                            nm_cidade,
                            nm_estado,
                            nm_bairro,
                            nm_rua,
                            ds_cep,
                            ds_complemento) VALUES(                            
                            @nm_funcionario,
                            @dt_nascimento,
                            @ds_rg,
                            @ds_cpf,
                            @ds_telefone,
                            @ds_email,
                            @id_depto,
                            @nm_cidade,
                            @nm_estado,
                            @nm_bairro,
                            @nm_rua,
                            @ds_cep,
                            @ds_complemento)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_funcionario", dto.Nome));
            parms.Add(new MySqlParameter("dt_nascimento", dto.Nascimento));
            parms.Add(new MySqlParameter("ds_rg", dto.RG));
            parms.Add(new MySqlParameter("ds_cpf", dto.CPF));
            parms.Add(new MySqlParameter("ds_telefone", dto.Telefone));
            parms.Add(new MySqlParameter("ds_email", dto.Email));
            parms.Add(new MySqlParameter("id_depto", dto.DeptoId));
            parms.Add(new MySqlParameter("nm_cidade", dto.Cidade));
            parms.Add(new MySqlParameter("nm_estado", dto.Estado));
            parms.Add(new MySqlParameter("nm_bairro", dto.Bairro));
            parms.Add(new MySqlParameter("nm_rua", dto.Rua));
            parms.Add(new MySqlParameter("ds_cep", dto.CPF));
            parms.Add(new MySqlParameter("ds_complemento", dto.COmplemento));

            Database db = new Database();
            int pk = db.ExecuteInsertScriptWithPk(script, parms);
            return pk;
        }

        public List<FuncionarioDTO> Listar()
        {
            string script = @"SELECT * FROM tb_funcionario";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<FuncionarioDTO> funcionarios = new List<FuncionarioDTO>();
            while (reader.Read())
            {
                FuncionarioDTO dto = new FuncionarioDTO();
                dto.Id = reader.GetInt32("id_funcionario");
                dto.Nome = reader.GetString("nm_funcionario");
                dto.Nascimento = reader.GetString("dt_nascimento");
                dto.RG = reader.GetString("ds_rg");
                dto.CPF = reader.GetString("ds_cpf");
                dto.Telefone = reader.GetString("ds_telefone");
                dto.Email = reader.GetString("ds_email");
                dto.DeptoId = reader.GetInt32("id_depto");
                dto.Cidade = reader.GetString("nm_cidade");
                dto.Estado = reader.GetString("nm_estado");
                dto.Bairro = reader.GetString("nm_bairro");
                dto.Rua = reader.GetString("nm_rua");
                dto.CEP = reader.GetString("ds_cep");
                dto.COmplemento = reader.GetString("ds_complemento");

                funcionarios.Add(dto);
            }
            reader.Close();

            return funcionarios;
        }

        public List<FuncionarioDTO> Consultar(string nome, string cidade)
        {
            string script = @"SELECT * FROM tb_funcionario WHERE nm_funcionario LIKE @nm_funcionario AND nm_cidade LIKE @nm_cidade";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_funcionario", nome + "%"));
            parms.Add(new MySqlParameter("nm_cidade", cidade + "%"));
            
            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<FuncionarioDTO> lista = new List<FuncionarioDTO>();
            while (reader.Read())
            {
                FuncionarioDTO dto = new FuncionarioDTO();
                dto.Id = reader.GetInt32("id_funcionario");
                dto.Nome = reader.GetString("nm_funcionario");
                dto.Nascimento = reader.GetString("dt_nascimento");
                dto.RG = reader.GetString("ds_rg");
                dto.CPF = reader.GetString("ds_cpf");
                dto.Telefone = reader.GetString("ds_telefone");
                dto.Email = reader.GetString("ds_email");
                dto.DeptoId = reader.GetInt32("id_depto");
                dto.Cidade = reader.GetString("nm_cidade");
                dto.Estado = reader.GetString("nm_estado");
                dto.Bairro = reader.GetString("nm_bairro");
                dto.Rua = reader.GetString("nm_rua");
                dto.CEP = reader.GetString("ds_cep");
                dto.COmplemento = reader.GetString("ds_complemento");

                lista.Add(dto);
            }
                        
            reader.Close();
            return lista;
        }

        public void Alterar(FuncionarioDTO dto)
        {
            string script = @"UPDATE tb_funcionario SET
                            nm_funcionario = @nm_funcionario,
                            dt_nascimento = @dt_nascimento,
                            ds_rg = @ds_rg,
                            ds_cpf = @ds_cpf,
                            ds_telefone = @ds_telefone,
                            ds_email = @ds_email,
                            id_depto = @id_depto,
                            nm_cidade = @nm_cidade,
                            nm_estado = @nm_estado,
                            nm_bairro = @nm_bairro,
                            nm_rua = @nm_rua,
                            ds_cep = @ds_cep,
                            ds_complemento = @ds_complemento WHERE
                            id_funcionario = @id_funcionario";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_funcionario", dto.Id));
            parms.Add(new MySqlParameter("nm_funcionario", dto.Nome));
            parms.Add(new MySqlParameter("dt_nascimento", dto.Nascimento));
            parms.Add(new MySqlParameter("ds_rg", dto.RG));
            parms.Add(new MySqlParameter("ds_cpf", dto.CPF));
            parms.Add(new MySqlParameter("ds_telefone", dto.Telefone));
            parms.Add(new MySqlParameter("ds_email", dto.Email));
            parms.Add(new MySqlParameter("id_depto", dto.DeptoId));
            parms.Add(new MySqlParameter("nm_cidade", dto.Cidade));
            parms.Add(new MySqlParameter("nm_estado", dto.Estado));
            parms.Add(new MySqlParameter("nm_bairro", dto.Bairro));
            parms.Add(new MySqlParameter("nm_rua", dto.Rua));
            parms.Add(new MySqlParameter("ds_cep", dto.CPF));
            parms.Add(new MySqlParameter("ds_complemento", dto.COmplemento));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
            
        }

        public void Remover(int Id)
        {
            string script = @"DELETE FROM tb_funcionario WHERE id_funcionario = @id_funcionario";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_funcionario", Id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);

        }
    }
}
