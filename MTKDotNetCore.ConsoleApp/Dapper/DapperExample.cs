using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCore.ConsoleApp.Dapper;

public class DapperExample
{
    #region Run
    public void Run()
    {
        // Read();
        //Edit(200);
        //Edit(2);
        // Create("testingtitle2", "testingauthor2", "testingcontnent2");
        //Update(2,"edited title2", "edited author2", "edited contnent2");
        Delete(13);
        

    }
    #endregion

    #region Read
    private void Read()
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);

        List<BlogModel>lst = db.Query<BlogModel>("select * from Tbl_Blog").ToList();
        foreach(BlogModel blog in lst) 
        { 
            Console.WriteLine(blog.BlogId);
            Console.WriteLine(blog.BlogTitle);
            Console.WriteLine(blog.BlogAuthor);
            Console.WriteLine(blog.BlogContent);
        }
    }
    #endregion

    #region Edit
    private void Edit(int id)
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
                  
        var item = db.Query<BlogModel>("select * from Tbl_Blog where BlogId = @BlogId", new BlogModel { BlogId = id }).FirstOrDefault();
            if (item is null)
            {
               Console.WriteLine("No Data Found");
               return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
    }
    #endregion

    #region Create
    private void Create(string title, string author, string content)
    {
        var item = new BlogModel
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        string query = @"INSERT INTO [dbo].[Tbl_Blog]
              ([BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent])

                VALUES
              (@BlogTitle
               ,@BlogAuthor
               ,@BlogContent)";

        using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Saving Successful" : "Saving Fail";
        Console.WriteLine(message);

    }
    #endregion

    #region Update
    private void Update(int id,string title,string author,string content)
    {
        var item = new BlogModel
        {
            BlogId = id,
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        string query = @"Update [dbo].[Tbl_Blog] 
        SET [BlogTitle] = @BlogTitle
        ,[BlogAuthor] = @BlogAuthor
        ,[BlogContent] = @BlogContent WHERE BlogId = @BlogId";

        using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);

        int result = db.Execute(query, item);
        string message = result > 0 ? "Updating Successful" : "Updating Fail";
        Console.WriteLine(message);
    }
    #endregion

    private void Delete(int id)
    {
        var item = new BlogModel
        {
            BlogId = id
        };
        string query = @"Delete from [dbo].[Tbl_Blog]
        WHERE BlogId = @BlogId";

        using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);

        int result = db.Execute(query,item);
        string message = result > 0 ? "Deleting Successful" : "Deleting Fail";
        Console.WriteLine(message);
    }
}
