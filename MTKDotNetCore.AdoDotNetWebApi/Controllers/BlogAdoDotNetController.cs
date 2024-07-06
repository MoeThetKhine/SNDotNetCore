using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.AdoDotNetWebApi.Model;
using System.Data;
using System.Data.SqlClient;
using MTKDotNetCore.AdoDotNetWebApi.Database;

namespace MTKDotNetCore.AdoDotNetWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogAdoDotNetController : ControllerBase
{

    [HttpGet]
    public IActionResult GetBlogs()
    {
        string query = "select * from Tbl_Blog";
        SqlConnection connection = new SqlConnection(ConnnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);
        connection.Close();

        //List<BlogModel> lst = new List<BlogModel>();
        //foreach(DataRow dr  in dt.Rows)
        //{
        //    BlogModel blog = new BlogModel();
        //    blog.BlogId = Convert.ToInt32(dr["BlogId"]);
        //    blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
        //    blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
        //    blog.BlogContent = Convert.ToString(dr["BlogContent"]);
        //    blog.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //    lst.Add(blog);
        //}

        List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
        {
            BlogId = Convert.ToInt32(dr["BlogId"]),
            BlogTitle = Convert.ToString(dr["BlogTitle"]),
            BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            BlogContent = Convert.ToString(dr["BlogContent"]),
            IsActive = Convert.ToBoolean(dr["IsActive"])

        }).ToList();
        return Ok(lst);
    }


    [HttpGet("{id}")]
    public IActionResult EditBlog(int id)
    {
        string query = "select * from Tbl_Blog WHERE BlogId = @BlogId";
        SqlConnection connection = new SqlConnection(ConnnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);
        connection.Close();

        if (dt.Rows.Count == 0)
        {
            return NotFound("No Data Found");
        }

        DataRow dr = dt.Rows[0];

        var item = new BlogModel
        {
            BlogId = Convert.ToInt32(dr["BlogId"]),
            BlogTitle = Convert.ToString(dr["BlogTitle"]),
            BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            BlogContent = Convert.ToString(dr["BlogContent"]),
            IsActive = Convert.ToBoolean(dr["IsActive"])

        };
        return Ok(item);
    }
    [HttpPost]
    public IActionResult CreateBlog(BlogModel blog)
    {
        string query = @"INSERT INTO [dbo].[Tbl_Blog]
        ([BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent])

                VALUES
              (@BlogTitle
               ,@BlogAuthor
               ,@BlogContent)";
        SqlConnection connection = new SqlConnection(ConnnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
        cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
        cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
        int result = cmd.ExecuteNonQuery();
        connection.Close();
        string message = result > 0 ? "Saving Successful" : "Saving Fail";
        return Ok(message);

    }

    [HttpPut("{id}")]
    public IActionResult UpdateBlog(int id, BlogModel blog)
    {
        SqlConnection connection = new SqlConnection(ConnnectionStrings._sqlConnectionStringBuilder.ConnectionString);

        connection.Open();
        string check = "select * from Tbl_Blog WHERE BlogId = @BlogId";
        SqlCommand chk = new SqlCommand(check, connection);
        chk.Parameters.AddWithValue("@BlogId", id);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(chk);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);
        connection.Close();

        if (dt.Rows.Count == 0)
        {
            return NotFound("No data found");
        }

        connection.Open();
        string query = @"Update[dbo].[Tbl_Blog] 
            SET[BlogTitle] = @BlogTitle
            ,[BlogAuthor] = @BlogAuthor
            ,[BlogContent] = @BlogContent Where BlogId = @BlogId";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
        cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
        cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);

        int result = cmd.ExecuteNonQuery();
        connection.Close();

        string message = result > 0 ? "Saving Successful" : "Saving Fail";
        return Ok(message);
    }
    
}





