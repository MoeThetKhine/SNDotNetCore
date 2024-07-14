using System.Data.SqlClient;

namespace MTKDotNetCore.AdoDotNetCustomService.Database;

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
