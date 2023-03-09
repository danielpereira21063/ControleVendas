using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVendas.br.com.projeto.conexao
{
    public class ConnectionFactory
    {
        public MySqlConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["bdvendas"].ConnectionString;

            return new MySqlConnection(connectionString);
        }
    }
}
