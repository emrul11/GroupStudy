using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonetTest
{
    public class DbConnection
    {
        public static SqlConnection Connection(string db="Student") {
            string ConString = $"data source=EMRUL\\SQLEXPRESS; database={db}; integrated security=SSPI";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            return con;
        }

    }
}
