#region using

using System.Data;
using System.Data.SqlClient;

#endregion

namespace MTKDotNetCore.ConsoleApp.AdoDotNet;

public class AdoDotNetExample
{
    #region Connection

    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder =
        new()
        {
            DataSource = "localhost",
            InitialCatalog = "OJTBatch1",
            IntegratedSecurity = true,
            TrustServerCertificate = true,
        };

    #endregion

    #region Read

    public async Task Read()
    {
        SqlConnection connection = new(_sqlConnectionStringBuilder.ConnectionString);

        #region DataTable

        await connection.OpenAsync();

        string query = "select * from Tbl_Blog";
        SqlCommand cmd = new(query, connection);
        SqlDataAdapter adapter = new(cmd);
        DataTable dt = new();
        adapter.Fill(dt);

        await connection.CloseAsync();

        #endregion

        #region Data Set

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine("Blog Id => " + dr["BlogId"]);
            Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
            Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
            Console.WriteLine("Blog Content => " + dr["BlogContent"]);
            Console.WriteLine("__________________________");
        }

        #endregion
    }

    #endregion

    #region Create

    public async Task Create(string title, string author, string content)
    {
        SqlConnection connection = new(_sqlConnectionStringBuilder.ConnectionString);
        await connection.OpenAsync();
        string query =
            @"INSERT INTO [dbo].[Tbl_Blog]
              ([BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent])

                VALUES
              (@BlogTitle
               ,@BlogAuthor
               ,@BlogContent)";
        SqlCommand cmd = new(query, connection);
        cmd.Parameters.AddWithValue("@BlogTitle", title);
        cmd.Parameters.AddWithValue("@BlogAuthor", author);
        cmd.Parameters.AddWithValue("@BlogContent", content);

        int result = await cmd.ExecuteNonQueryAsync();
        await connection.CloseAsync();
        string message = result > 0 ? "Saving Successful" : "Saving Fail";

        Console.WriteLine(message);
    }

    #endregion

    #region Update

    public async Task Update(int id, string title, string author, string content)
    {
        SqlConnection connection = new(_sqlConnectionStringBuilder.ConnectionString);
        await connection.OpenAsync();
        string query =
            @"Update[dbo].[Tbl_Blog] 
            SET[BlogTitle] = @BlogTitle
            ,[BlogAuthor] = @BlogAuthor
            ,[BlogContent] = @BlogContent Where BlogId = @BlogId";

        SqlCommand cmd = new(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        cmd.Parameters.AddWithValue("@BlogTitle", title);
        cmd.Parameters.AddWithValue("@BlogAuthor", author);
        cmd.Parameters.AddWithValue("@BlogContent", content);

        int result = await cmd.ExecuteNonQueryAsync();
        await connection.CloseAsync();
        string message = result > 0 ? "Updating Successful" : "Updating Fail";

        Console.WriteLine(message);
    }

    #endregion

    #region Delete

    public async Task Delete(int id)
    {
        SqlConnection connection = new(_sqlConnectionStringBuilder.ConnectionString);
        await connection.OpenAsync();
        string query = @"DELETE from Tbl_Blog WHERE BlogId = @BlogId";
        SqlCommand cmd = new(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        int result = await cmd.ExecuteNonQueryAsync();
        await connection.CloseAsync();

        string message = result > 0 ? "Deleting Successful" : "Deleting Fail";
        Console.WriteLine(message);
    }

    #endregion

    #region Edit

    public async Task Edit(int id)
    {
        SqlConnection connection = new(_sqlConnectionStringBuilder.ConnectionString);
        await connection.OpenAsync();
        string query = @"select * from Tbl_Blog where BlogId = @BlogId";

        SqlCommand cmd = new(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        SqlDataAdapter sqlDataAdapter = new(cmd);
        DataTable dt = new();
        sqlDataAdapter.Fill(dt);
        await connection.CloseAsync();

        await connection.CloseAsync();
        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("No Data Found");
            return;
        }
        DataRow dr = dt.Rows[0];

        Console.WriteLine("Blog Id => " + dr["BlogId"]);
        Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
        Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
        Console.WriteLine("Blog Content => " + dr["BlogContent"]);
        Console.WriteLine("__________________________");
    }

    #endregion
}
