using AppBancoADO;
using AppBancoDominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDLL
{
    public class UsuarioDAO
    {
        private Banco db;
        public void InsertUsuario (Usuario usuario)
        {
            var strQuery = "";
            strQuery += "INSERT INTO tb_liaUsuario ";
            strQuery += string.Format("VALUES (default, '{0}', '{1}', STR_TO_DATE('{2}', '%d/%m/%Y %T'))",
                            usuario.Nome, usuario.Cargo, usuario.DataNasc.Date);
            
            using (db =  new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void AtualizarUsuario (Usuario usuario)
        {
            var strQuery = "";
            strQuery += "UPDATE tb_liaUsuario SET ";
            strQuery += string.Format("NomeUsu = '{0}', ", usuario.Nome);
            strQuery += string.Format("Cargo = '{0}', ", usuario.Cargo);
            strQuery += string.Format("DtNasc = STR_TO_DATE('{0}', '%d/%m/%Y %T') ", usuario.DataNasc.Date);
            strQuery += string.Format("WHERE IdUsu = {0};", usuario.Id);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void SalvarUsuario (Usuario usuario)
        {
            if (usuario.Id > 0)
            {
                AtualizarUsuario(usuario);
            } else
            {
                InsertUsuario(usuario);
            }
        }

        public void ExcluirUsuario (int id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("DELETE FROM tb_liaUsuario WHERE IdUsu = {0}", id);
                db.ExecutaComando(strQuery);
            }
        }

        public List<Usuario> ListarUsuario()
        {
            using (db = new Banco())
            {
                var strQuery = "SELECT * FROM tb_liaUsuario;";
                var retorno = db.RetornaComando(strQuery);
                return ListaDeUsuarios(retorno);
            }
        }
        public List<Usuario> ListaDeUsuarios(MySqlDataReader retorno)
        {
            var usuarios = new List<Usuario>();
            while (retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    Id = int.Parse(retorno["IdUsu"].ToString()),
                    Nome = retorno["NomeUsu"].ToString(),
                    Cargo = retorno["Cargo"].ToString(),
                    DataNasc = DateTime.Parse(retorno["DtNasc"].ToString())
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }
     }
}
