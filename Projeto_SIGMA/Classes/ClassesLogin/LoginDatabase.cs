using MySql.Data.MySqlClient;
using Projeto_SIGMA.Classes.ClassesConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SIGMA.Classes.ClassesLogin
{
    public class LoginDatabase
    {
        public int Salvar(LoginDTO dto)
        {
            string script = @"INSERT INTO tb_login(
                            nm_usuario,
                            ds_senha,
                            nm_completo,
                            ds_email,
                            pr_permissaoAdm,
                            pr_permissaoCadastrar,
                            pr_permissaoConsultar,
                            pr_permissaoOrcamento,
                            pr_permissaoPedido) VALUES(
                            @nm_usuario,
                            @ds_senha,
                            @nm_completo,
                            @ds_email,
                            @pr_permissaoAdm,
                            @pr_permissaoCadastro,
                            @pr_permissaoConsulta,
                            @pr_permissaoOrcamento,
                            @pr_permissaoPedido)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_usuario", dto.Usuario));
            parms.Add(new MySqlParameter("ds_senha", dto.Senha));
            parms.Add(new MySqlParameter("nm_completo", dto.Nome));
            parms.Add(new MySqlParameter("ds_email", dto.Email));
            parms.Add(new MySqlParameter("pr_permissaoAdm", dto.PermissaoAdm));
            parms.Add(new MySqlParameter("pr_permissaoCadastro", dto.PermissaoCadastro));
            parms.Add(new MySqlParameter("pr_permissaoConsulta", dto.PermissaoConsulta));
            parms.Add(new MySqlParameter("pr_permissaoOrcamento", dto.PermissaoOrcamento));
            parms.Add(new MySqlParameter("pr_permissaoPedido", dto.PermissaoPedido));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);            
        }

        public LoginDTO Logar(string usuario, string senha)
        {
            string script = @"SELECT * FROM tb_login WHERE nm_usuario = @nm_usuario AND ds_senha = @ds_senha";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_usuario", usuario));
            parms.Add(new MySqlParameter("ds_senha", senha));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            LoginDTO dto = null;
            if (reader.Read())
            {
                dto = new LoginDTO();
                dto.Id = reader.GetInt32("id_login");
                dto.Usuario = reader.GetString("nm_usuario");
                dto.Senha = reader.GetString("ds_senha");
                dto.Nome = reader.GetString("nm_completo");
                dto.Email = reader.GetString("ds_email");
                dto.PermissaoAdm = reader.GetBoolean("pr_permissaoAdm");
                dto.PermissaoCadastro = reader.GetBoolean("pr_permissaoCadastrar");
                dto.PermissaoConsulta = reader.GetBoolean("pr_permissaoConsultar");
            }

            reader.Close();
            return dto;
        }
    }
}
