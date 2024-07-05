﻿using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.DapperRestApi.Database;
using MTKDotNetCore.DapperRestApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace MTKDotNetCore.DapperRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";
            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();
            return Ok(lst);
        }
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

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog) 
        {
            string query = @"Insert into [dbo].[Tbl_Blog]
            ([BlogTitle]
            ,[BlogAuthor]
            ,[BlogContent])
            VALUES(@BlogTitle
            ,@BlogAuthor
            ,@BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query,blog);
            string message = result > 0 ? "Saving Successful" : "Saving Fail";
            return Ok(message);


        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,BlogModel blog)
        {
            var item = FindById(id);
            if(item is null)
            {
                return NotFound("No Data Found");
            }
            string query = "select * from Tbl_Blog WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            string message = result > 0 ? "Updating Successful" : "Updating Fail";
            return Ok(message);
        }
        private BlogModel? FindById(int id)
        {
            string query = "select * from Tbl_Blog WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            return item;
        }
    }

   
}
