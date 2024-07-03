using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCore.ConsoleApp.Dapper
{
    public class ConnectionStrings
    {
        public static SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
                 DataSource = "localhost", // or "(local)" or your server name
                 InitialCatalog = "OJTBatch1",
                 IntegratedSecurity = true,
                 TrustServerCertificate = true,
    };
    }
}
