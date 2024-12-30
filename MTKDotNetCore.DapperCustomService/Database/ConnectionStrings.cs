namespace MTKDotNetCore.DapperCustomService.Database;

#region Connection String

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

#endregion