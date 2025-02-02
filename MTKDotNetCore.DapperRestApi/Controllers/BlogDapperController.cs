﻿namespace MTKDotNetCore.DapperRestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogDapperController : ControllerBase
{
    #region GetBlogs
    [HttpGet]
    public IActionResult GetBlogs()
    {
        string query = "select * from Tbl_Blog";
        using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        List<BlogModel> lst = db.Query<BlogModel>(query).ToList();
        return Ok(lst);
    }
    #endregion

    #region EditBlog
    
    [HttpGet("{id}")]
    public IActionResult EditBlog(int id)
    {
        //string query = "select * from Tbl_Blog WHERE BlogId = @BlogId";
        //using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        //var item = db.Query<BlogModel>(query,new BlogModel {BlogId = id}).FirstOrDefault();

        var item = FindById(id);
        if (item is null)
        {
            return NotFound("No Data Found");
        }
        return Ok(item);
    }
    #endregion

    #region CreateBlog

    [HttpPost]
    public IActionResult CreateBlog(BlogModel blog) 
    {
        string query = @"Insert into [dbo].[Tbl_Blog]
            ([BlogTitle]
            ,[BlogAuthor]
            ,[BlogContent]
            ,[IsActive])
            VALUES(@BlogTitle
            ,@BlogAuthor
            ,@BlogContent
            ,@IsActive)";

        using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);

        int result = db.Execute(query,blog);
        string message = result > 0 ? "Creating Successful" : "Creating Fail";
        return Ok(message);
    }
    #endregion

    #region UpdateBlog
    [HttpPut("{id}")]
    public IActionResult UpdateBlogs(int id, BlogModel blog)
    {
        var item = FindById(id);
        if (item is null)
        {
            return NotFound("No Data Found");
        }

        string query = @"
        UPDATE [dbo].[Tbl_Blog]
        SET [BlogTitle] = @BlogTitle,
            [BlogAuthor] = @BlogAuthor,
            [BlogContent] = @BlogContent,
            [IsActive] = @IsActive
        WHERE blogid = @BlogId";

        using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, new
        {
            BlogTitle = blog.BlogTitle,
            BlogAuthor = blog.BlogAuthor,
            BlogContent = blog.BlogContent,
            IsActive = blog.IsActive,
            BlogId = id
        });

        string message = result > 0 ? "Updating Successful" : "Updating Fail";
        return Ok(message);
    }
    #endregion

    #region PatchBlog

    [HttpPatch("{id}")]
    public IActionResult PatchBlog(int id,BlogModel blog)
    {
        var item = FindById(id);
        if(item is null)
        {
            return NotFound("No Data Found");
        }
        string conditions = string.Empty;
        if(!string.IsNullOrEmpty(blog.BlogTitle))
        {
            conditions += "[BlogTitle] = @BlogTitle, ";
        }
        if (!string.IsNullOrEmpty(blog.BlogAuthor))
        {
            conditions += "[BlogAuthor] = @BlogAuthor, ";
        }
        if (!string.IsNullOrEmpty(blog.BlogContent))
        {
            conditions += "[BlogContent] = @BlogContent, ";
        }
        if(conditions.Length == 0) 
        {
            return NotFound("No data to update");
        }
        conditions = conditions.Substring(0,conditions.Length - 2);
        blog.BlogId = id;

        string query = $@"Update[dbo].[Tbl_Blog] SET {conditions} WHERE BlogId = @BlogId";
        using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, blog);
        string message = result > 0 ? "Updating Successful" : "Updating Fail";
        return Ok(message);
    }
    #endregion

    #region DeleteBlog

    [HttpDelete("{id}")]
    public IActionResult DeleteBlog(int id)
    {
        var item = FindById(id);
        if (item is null)
        {
            return NotFound("No Data Found");
        }
        string query = @"Delete from [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
        using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, new BlogModel { BlogId = id });
        string message = result > 0 ? "Deleting Successful" : "Deleting Fail";
        return Ok(message);
    }
    #endregion

    #region FindById
    private BlogModel? FindById(int id)
    {
        string query = "select * from Tbl_Blog WHERE BlogId = @BlogId";
        using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
        return item;
    }
    #endregion
}
