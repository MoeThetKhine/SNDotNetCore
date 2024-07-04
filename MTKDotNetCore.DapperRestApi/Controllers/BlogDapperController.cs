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
        [HttpGet("{id}")]
        public IActionResult EditBlog(int id) 
        {
            string query = "select * from Tbl_Blog WHERE blogid = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);

            var item = db.Query<BlogModel>(query,new BlogModel { BlogId = id}).FirstOrDefault(); 
            if(item is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(item);    


        }
    }
}
