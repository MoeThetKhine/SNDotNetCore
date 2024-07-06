using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace MTKDotNetCore.DapperCustomService.Shared
{
    public class DapperCustomService
    {
        private readonly string _connectionSring;

        public DapperCustomService(string connectionSring)
        {
            _connectionSring = connectionSring;
        }
        public List<M>Query<M>(string query,object? param = null) 
        {
            using IDbConnection db = new SqlConnection(_connectionSring);
            var lst = db.Query<M>(query,param).ToList();
            return lst;


        }
        public int Execute(string query,object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionSring);
            var result = db.Execute(query,param);
            return result;


        }

        public M QueryFirstOrDefault<M>(string query,object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionSring);
            var item = db.Query<M>(query, param).FirstOrDefault();
            return item!;
        }

        
    }
}
