#region using

using System.Data.SqlClient;

#endregion

namespace MTKDotNetCore.ConsoleApp.Dapper;

#region ConnectionString

public class ConnectionStrings
{
    public static SqlConnectionStringBuilder _sqlConnectionStringBuilder =
        new()
        {
            DataSource = "localhost", 
            InitialCatalog = "OJTBatch1",
            IntegratedSecurity = true,
            TrustServerCertificate = true
        };
}

#endregion
