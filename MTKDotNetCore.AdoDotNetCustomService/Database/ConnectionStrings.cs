using System.Data.SqlClient;

namespace MTKDotNetCore.AdoDotNetCustomService.Database
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
