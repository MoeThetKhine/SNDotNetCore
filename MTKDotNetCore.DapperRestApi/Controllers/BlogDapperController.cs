using Dapper;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.DapperRestApi.Database;
using MTKDotNetCore.DapperRestApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace MTKDotNetCore.DapperRestApi.Controllers
{
    public class BlogDapperController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";
            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel>lst = db.Query<BlogModel>(query).ToList();
            return Ok(lst);
        }
    }
}
