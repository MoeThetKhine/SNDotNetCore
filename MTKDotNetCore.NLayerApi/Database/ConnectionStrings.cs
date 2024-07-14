using System.Data.SqlClient;

namespace MTKDotNetCore.NLayerApi.Database;

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
