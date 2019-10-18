using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Capgemini.Pecunia.Helpers
{
    public class SQLServerUtil
    {
        //public static SqlConnection getConnetion(string serverName, string databaseName, string user, string password)
        //{
        //    string connectionString = $"Data Source={serverName}; Initial Catalog={databaseName}; User ID={user}; Password={password}";
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    return conn;
        //}

        public static SqlConnection getConnetion(string databaseName)
        {
            string connectionString = $"Server=localhost;Database={databaseName};Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connectionString);

            return conn;
        }

        
    }
}
