using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.DapperCustomerService.Model;
using MTKDotNetCore.DapperCustomerService.Shared;

namespace MTKDotNetCore.DapperCustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        private readonly DapperCustomService _dapperCustomService;

        public BlogDapperController(DapperCustomService dapperCustomService)
        {
            _dapperCustomService = dapperCustomService;
        }
       
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";
            var lst = _dapperCustomService.Query<BlogModel>(query);

            return Ok(lst);
        }

        private BlogModel? FindById(int id)
        {
            string query = "select * from Tbl_Blog where BogId = @BlogId";
            var item = _dapperCustomService.QueryFirstOrDefault<BlogModel>(query,new BlogModel { BlogId = id});
            return item;
        }

        [HttpGet("{id}")]
        public IActionResult EditBlog(int id)
        {
            var item = FindById(id);
            if(item is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(item);
        }

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
            int result = _dapperCustomService.Execute(query,blog);
            string message = result > 0 ? "Saving Successful" : "Saving Fail";
            return Ok(message);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,BlogModel blog)
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
            int result = _dapperCustomService.Execute(query, blog);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);
            if(item is null)
            {
                return NotFound("No Data Found");
            }
            string query = @"Delete from [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
            int result = _dapperCustomService.Execute(query, new BlogModel { BlogId = id });
            string message = result > 0 ? "Deleting Successful" : "Deleting Fail";
            return Ok(message);

        }



        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id,BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
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
            if (conditions.Length == 0)
            {
                return NotFound("No data to update");
            }
            conditions = conditions.Substring(0, conditions.Length - 2);
            blog.BlogId = id;

            string query = $@"Update[dbo].[Tbl_Blog] SET {conditions} WHERE BlogId = @BlogId";
            int result = _dapperCustomService.Execute(query, blog);
            string message = result > 0 ? "Updating Successful" : "Updating Fail";
            return Ok(message);
        }
    }
}
