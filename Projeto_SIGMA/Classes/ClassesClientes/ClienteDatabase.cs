using MySql.Data.MySqlClient;
using Projeto_SIGMA.Classes.ClassesConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesClientes
{
    public class ClienteDatabase
    {
        public int Salvar(ClienteDTO dto)
        {
          
                string script = @"INSERT INTO tb_cliente(
                    nm_cliente,
                    ds_email,
                    ds_cpf,
                    ds_rg,
                    dt_nascimento,
                    ds_telefone,
                    nm_cidade,
                    nm_estado,
                    nm_bairro) VALUES(
                    @nm_cliente,
                    @ds_email,
                    @ds_cpf,
                    @ds_rg,
                    @dt_nascimento,
                    @ds_telefone,
                    @nm_cidade,
                    @nm_estado,
                    @nm_bairro)";

                List<MySqlParameter> parms = new List<MySqlParameter>();
                parms.Add(new MySqlParameter("nm_cliente", dto.Nome));
                parms.Add(new MySqlParameter("ds_email", dto.Email));
                parms.Add(new MySqlParameter("ds_cpf", dto.CPF));
                parms.Add(new MySqlParameter("ds_rg", dto.RG));
                parms.Add(new MySqlParameter("dt_nascimento", dto.Nascimento));
                parms.Add(new MySqlParameter("ds_telefone", dto.Telefone));
                parms.Add(new MySqlParameter("nm_cidade", dto.Cidade));
                parms.Add(new MySqlParameter("nm_estado", dto.Estado));
                parms.Add(new MySqlParameter("nm_bairro", dto.Bairro));

                Database db = new Database();
                return db.ExecuteInsertScriptWithPk(script, parms);
            
          
          
        }

        public List<ClienteDTO> Listar()
        {
            string script = @"SELECT * FROM tb_cliente";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<ClienteDTO> lista = new List<ClienteDTO>();
            while (reader.Read())
            {
                ClienteDTO dto = new ClienteDTO();
                dto.Id = reader.GetInt32("id_cliente");
                dto.Nome = reader.GetString("nm_cliente");
                dto.Email = reader.GetString("ds_email");
                dto.CPF = reader.GetString("ds_cpf");
                dto.RG = reader.GetString("ds_rg");
                dto.Nascimento = reader.GetString("dt_nascimento");
                dto.Telefone = reader.GetString("ds_telefone");
                dto.Cidade = reader.GetString("nm_cidade");
                dto.Estado = reader.GetString("nm_estado");
                dto.Bairro = reader.GetString("nm_bairro");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public List<ClienteDTO> Consultar(string nome, string cidade)
        {
            string script = @"SELECT * FROM tb_cliente WHERE nm_cliente LIKE @nm_cliente AND nm_cidade LIKE @nm_cidade";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_cliente", nome + "%"));
            parms.Add(new MySqlParameter("nm_cidade", cidade + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);
            List<ClienteDTO> lista = new List<ClienteDTO>();

            while (reader.Read())
            {
                ClienteDTO dto = new ClienteDTO();
                dto.Id = reader.GetInt32("id_cliente");
                dto.Nome = reader.GetString("nm_cliente");
                dto.Email = reader.GetString("ds_email");
                dto.CPF = reader.GetString("ds_cpf");
                dto.RG = reader.GetString("ds_rg");
                dto.Nascimento = reader.GetString("dt_nascimento");
                dto.Telefone = reader.GetString("ds_telefone");
                dto.Cidade = reader.GetString("nm_cidade");
                dto.Estado = reader.GetString("nm_estado");
                dto.Bairro = reader.GetString("nm_bairro");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }   

        public void Alterar(ClienteDTO dto)
        {
            string script = @"UPDATE tb_cliente SET
                    nm_cliente = @nm_cliente,
                    ds_email = @ds_email,
                    ds_cpf = @ds_cpf,
                    ds_rg = @ds_rg,
                    dt_nascimento = @dt_nascimento,
                    ds_telefone = @ds_telefone,
                    nm_cidade = @nm_cidade,
                    nm_estado = @nm_estado,
                    nm_bairro = @nm_bairro WHERE
                    id_cliente = @id_cliente";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_cliente", dto.Id));
            parms.Add(new MySqlParameter("nm_cliente", dto.Nome));
            parms.Add(new MySqlParameter("ds_email", dto.Email));
            parms.Add(new MySqlParameter("ds_cpf", dto.CPF));
            parms.Add(new MySqlParameter("ds_rg", dto.RG));
            parms.Add(new MySqlParameter("dt_nascimento", dto.Nascimento));
            parms.Add(new MySqlParameter("ds_telefone", dto.Telefone));
            parms.Add(new MySqlParameter("nm_cidade", dto.Cidade));
            parms.Add(new MySqlParameter("nm_estado", dto.Estado));
            parms.Add(new MySqlParameter("nm_bairro", dto.Bairro));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public void Remover(int Id)
        {
            string script = @"DELETE FROM tb_cliente WHERE id_cliente = @id_cliente";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_cliente", Id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
    }
}
