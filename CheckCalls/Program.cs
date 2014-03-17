using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Data;

namespace CheckCalls
{
    class Program
    {
        static void Main(string[] args)
        {

            var vConString = ConfigurationManager.ConnectionStrings["DBLOWCon"];
            string sConn = vConString.ConnectionString;
            string sProc = System.Configuration.ConfigurationManager.AppSettings["StoredProc"];
            
            using (var conn = new SqlConnection(sConn))
            using (var command = new SqlCommand(sProc, conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }

        }
    }
}
