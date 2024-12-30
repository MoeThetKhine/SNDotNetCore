namespace MTKDotNetCore.AdoDotNetCustomService.Database;

#region Connection String

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