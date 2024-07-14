#region using

using System.Data.SqlClient;

#endregion

namespace MTKDotNetCore.ConsoleApp.Dapper
{
    #region ConnectionStrings
    public class ConnectionStrings
    {
        public static SqlConnectionStringBuilder _sqlConnectionStringBuilder =
            new SqlConnectionStringBuilder()
            {
                DataSource = "localhost", // or "(local)" or your server name
                InitialCatalog = "OJTBatch1",
                IntegratedSecurity = true,
                TrustServerCertificate = true,
            };
    }
    #endregion
}
