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
   public void Run()
    {
        // Read();
        //Edit(200);
        //Edit(2);
        Create("testingtitle2", "testingauthor2", "testingcontnent2");
    }
    public void Read()
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
    #region Edit
    public void Edit(int id)
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

}
