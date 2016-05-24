using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DapperTest
{
    public class DbContext
    {
        public static MySqlConnection GetConnection(bool noDb = false)
        {
            if (noDb)
            {
                return new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLconnStr"].ConnectionString);
            }

            return new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLDbconnStr"].ConnectionString);
        }
    }
}
