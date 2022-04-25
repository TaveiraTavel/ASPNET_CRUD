using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Configuration;

namespace AppBancoADO
{
    public class Banco :IDisposable
    {
        private readonly MySqlConnection conexao;

         public Banco()
        {
            conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void ExecutaComando(string StrQuery)
        {
            var comando = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType = CommandType.Text, // facultativo: pode ser StoredProcedure ou TableDirect
                Connection = conexao
            };
            comando.ExecuteNonQuery();
        }
        
        public MySqlDataReader RetornaComando(string StrQuery)
        {
            var comando = new MySqlCommand(StrQuery, conexao);
            return comando.ExecuteReader();
        }
    }
}
