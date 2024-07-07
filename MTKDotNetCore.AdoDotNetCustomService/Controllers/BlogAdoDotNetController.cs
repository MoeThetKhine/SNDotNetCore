﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.AdoDotNetCustomService.Model;
using MTKDotNetCore.AdoDotNetCustomService.Shares;
using System.Data;
using System.Reflection.Metadata;
using static MTKDotNetCore.AdoDotNetCustomService.Shares.AdoDotNetService;

namespace MTKDotNetCore.AdoDotNetCustomService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetCustomService;

        public BlogAdoDotNetController(AdoDotNetService adoDotNetCustomService)
        {
            _adoDotNetCustomService = adoDotNetCustomService;
        }
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";
            var lst = _adoDotNetCustomService.Query<BlogModel>(query);
            return Ok(lst);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            string query = "select * from Tbl_Blog where BlogId = @BlogId";
            var item = _adoDotNetCustomService.FirstOrDefault<BlogModel>(query,new AdoDotNetParameter("@BlogId",id));

            if(item is null)
            {
                return NotFound("No Data Found");
            }
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
            int result = _adoDotNetCustomService.Execute(query,
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent",blog.BlogContent)
                );
            string message = result > 0 ? "Saving Successful" : "Saving Fail";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,BlogModel blog)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
                        SET [BlogTitle] = @BlogTitle,
                            [BlogAuthor] = @BlogAuthor,
                            [BlogContent] = @BlogContent
                        WHERE [BlogId] = @BlogId";

            int result = _adoDotNetCustomService.Execute(query,
                new AdoDotNetParameter("@BlogId", id),
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle!),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor!),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent!)
            );

            string message = result > 0 ? "Update Successful." : "Update Failed.";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        
        public IActionResult DeleteBlog(int id)
        {
            string query = @"Delete from Tbl_Blog WHERE BlogId = @BlogId";
            int result = _adoDotNetCustomService.Execute(query, new AdoDotNetParameter("@BlogId", id));
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message);
        }

        //[HttpPatch("{id}")]
        //public IActionResult PatchBlog(int id, BlogModel blog)
        //{
        //    List<AdoDotNetParameter> lst = new List<AdoDotNetParameter>();
        //    string conditions = string.Empty;
        //    if (!string.IsNullOrEmpty(blog.BlogTitle))
        //    {
        //        conditions += " [BlogTitle] = @BlogTitle, ";
        //        lst.Add("@BlogTitle", blog.BlogTitle);
        //    }

        //    if (!string.IsNullOrEmpty(blog.BlogAuthor))
        //    {
        //        conditions += " [BlogAuthor] = @BlogAuthor, ";
        //        lst.Add("@BlogAuthor", blog.BlogAuthor);
        //    }

        //    if (!string.IsNullOrEmpty(blog.BlogContent))
        //    {
        //        conditions += " [BlogContent] = @BlogContent, ";
        //        lst.Add("@BlogContent", blog.BlogContent);
        //    }

        //    if (conditions.Length == 0)
        //    {
        //        var response = new { IsSuccess = false, Message = "No data found." };
        //        return NotFound(response);
        //    }

        //    lst.Add(new AdoDotNetParameter("@BlogId", id));

        //    conditions = conditions.Substring(0, conditions.Length - 2);
        //    string query = $@"UPDATE [dbo].[Tbl_Blog] SET {conditions} WHERE BlogId = @BlogId";

        //    int result = _adoDotNetService.Execute(query,
        //        lst.ToArray()
        //    );

        //    string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        //    return Ok(message);
        //}



        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id,BlogModel blog)
        {
            List<AdoDotNetParameter> lst = new List<AdoDotNetParameter>();
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += " [BlogTitle] = @BlogTitle, ";
                lst.Add("@BlogTitle", blog.BlogTitle);
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += " [BlogAuthor] = @BlogAuthor, ";
                lst.Add("@BlogAuthor", blog.BlogAuthor);
            }
        }
    }
}
