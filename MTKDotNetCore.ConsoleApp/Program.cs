using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

#region Connection

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();

SqlConnection connection = new SqlConnection("Data Source=(local);Initial Catalog=OJTBatch1;Integrated Security=True;TrustServerCertificate=True");

#endregion

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

Console.ReadKey();
