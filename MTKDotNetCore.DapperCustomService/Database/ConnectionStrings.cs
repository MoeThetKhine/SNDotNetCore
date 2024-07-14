using System.Data.SqlClient;

namespace MTKDotNetCore.DapperCustomService.Database;

public class ConnectionStrings
{
    public static SqlConnectionStringBuilder _sqlConnectionStringBuilder =
        new SqlConnectionStringBuilder()
        {
            DataSource = "localhost",
            InitialCatalog = "OJTBatch1",
            IntegratedSecurity = true,
            TrustServerCertificate = true
        };
}
