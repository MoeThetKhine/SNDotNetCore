using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();

SqlConnection connection = new SqlConnection("Data Source=(local);Initial Catalog=OJTBatch1;Integrated Security=True;TrustServerCertificate=True");

connection.Open();
Console.WriteLine("Connection Open");
connection.Close();
Console.WriteLine("Connection Close");

Console.ReadKey();
