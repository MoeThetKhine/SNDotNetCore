using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace MTKDotNetCore.AdoDotNetCustomService.Shares
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<T>Query<T>(string query,params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query,connection);

            if (parameters is not null && parameters.Length > 0)
            {
                //foreach(var item in parameters)
                //{
                //    cmd.Parameters.AddWithValue(item.Name,item.Value);
                //}


                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            string json = JsonConvert.SerializeObject(dt); // C# to Json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; //Json to C#
            return lst;

        }

        public int Execute(string query,params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);

            if (parameters is not null && parameters.Length > 0)
            {
                //foreach (var item in parameters)
                //{
                //    cmd.Parameters.AddWithValue(item.Name, item.Value);
                //}

                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;


        }

        public T FirstOrDefault<T>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);

            if (parameters is not null && parameters.Length > 0)
            {
                //foreach(var item in parameters)
                //{
                //    cmd.Parameters.AddWithValue(item.Name,item.Value);
                //}


                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            string json = JsonConvert.SerializeObject(dt); // C# to Json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; //Json to C#
            return lst[0];

        }
        public class AdoDotNetParameter
        {
            public AdoDotNetParameter() { }
            public AdoDotNetParameter(string name,object value) 
            {
                Name = name;
                Value = value;
            }
            public string Name { get; set; }    
            public object Value { get; set; }

        }

       
    }
}
