namespace MTKDotNetCore.AdoDotNetWebApi.Database;

#region ConnnectionStrings

public class ConnnectionStrings
{
    
    public static SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "localhost", // or "(local)" or your server name
        InitialCatalog = "OJTBatch1",
        IntegratedSecurity = true,
        TrustServerCertificate = true,
    };
}

#endregion