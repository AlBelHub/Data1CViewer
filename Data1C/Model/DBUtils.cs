using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Data1C.Model
{
    public class DBUtils
    {
        private MySqlConnection? conn;
        private string? ConString;

        /// <summary>
        /// https://dev.mysql.com/doc/connector-net/en/connector-net-connections-string.html#connector-net-connections-open
        /// </summary>
        public DBUtils(string DBname,string UID, string DBpassword, string ServerAddr)
        {
            ConString = $"server={ServerAddr};uid={UID};pwd={DBpassword};database={DBname}";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = ConString;
                conn.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
