using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Capgemini.Pecunia.Helpers
{
    public class sqlCommonClass
    {
        public static SqlConnection getConnection(string serverName, string databaseName, string userName, string password)
        {
            string connectionString = $"Data Source={serverName}; Initial Catalog ={databaseName}; User Id = {userName}; Password= {password}";
            SqlConnection conn = new SqlConnection(connectionString);

            return conn;

        }
    }
}
