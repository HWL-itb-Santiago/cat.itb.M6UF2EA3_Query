using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF2EA3.Connections
{
    public class CloudConnection
    {
        public string Username = "santiagovr";
        public string host = "postgresql-santiagovr.alwaysdata.net";
        public string db = "santiagovr_mapsh";
        public string password = "Chistrees69@";

        public NpgsqlConnection GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Username = " + Username + ";" + "Password = " + password + ";" + "Database = " + db + ";" + "Host = " + host + ";");
            conn.Open();
            return conn;
        }
    }
}
