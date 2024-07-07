using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace MTKDotNetCore.DapperCustomService.Shares
{
    public class DapperService
    {
        public readonly string _connectionString;

        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<M> Query<M>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var lst = db.Query<M>(query, param).ToList();
            return lst;
        }
        public int Execute(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Execute(query, param);
            return result;
        }
        public M QueryFirstOrDefault<M>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var item = db.Query<M>(query, param).FirstOrDefault();
            return item!;
        }

    }
}
