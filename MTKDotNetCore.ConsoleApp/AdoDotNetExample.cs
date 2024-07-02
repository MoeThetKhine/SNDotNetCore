#region using

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace MTKDotNetCore.ConsoleApp
{
    public class AdoDotNetExample
    {
        #region Connection

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "localhost", // or "(local)" or your server name
            InitialCatalog = "OJTBatch1",
            IntegratedSecurity = true,
            TrustServerCertificate = true,
        };

        #endregion

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            #region DataTable

            connection.Open();
            Console.WriteLine("Connection Open");

            string query = "select * from Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataadapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataadapter.Fill(dt);

            connection.Close();
            Console.WriteLine("Connection Close");

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

        #region Create

        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
              ([BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent])

                VALUES
              (@BlogTitle
               ,@BlogAuthor
               ,@BlogContent)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Saving Successful" : "Saving Failed";

            Console.WriteLine(message);
        }

        #endregion

    }
}
