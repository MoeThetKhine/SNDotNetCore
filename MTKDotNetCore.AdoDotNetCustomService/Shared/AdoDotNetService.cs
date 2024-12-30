using System.Data;

namespace MTKDotNetCore.AdoDotNetCustomService.Shared;

public class AdoDotNetService
{
    private readonly string _connectionString;

    public AdoDotNetService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<T> Query<T>(string query, params AdoDotNetParameter[]? parameters)
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


            var parametersArray = parameters
                .Select(item => new SqlParameter(item.Name, item.Value))
                .ToArray();
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

    public int Execute(string query, params AdoDotNetParameter[]? parameters)
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

            var parametersArray = parameters
                .Select(item => new SqlParameter(item.Name, item.Value))
                .ToArray();
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


            var parametersArray = parameters
                .Select(item => new SqlParameter(item.Name, item.Value))
                .ToArray();
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

    public async Task<List<T>> QueryAsync<T>(
        string query,
        AdoDotNetParameter[]? parameters = null,
        SqlTransaction? transaction = null
    )
    {
        SqlConnection conn = GetConnection();
        await conn.OpenAsync();

        SqlCommand cmd = new(query, conn, transaction);
        if (parameters is not null && parameters.Length > 0)
        {
            var paramsLst = parameters.Select(x => x.Map());
            cmd.Parameters.AddRange(paramsLst.ToArray());
        }
        SqlDataAdapter adapter = new(cmd);
        DataTable dt = new();
        adapter.Fill(dt);

        await conn.CloseAsync();

        string jsonStr = dt.SerializeObject();
        var lst = jsonStr.DeserializeObject<List<T>>()!;

        return lst;
    }

    public async Task<DataTable> QueryFirstOrDefaultAsync(
        string query,
        AdoDotNetParameter[]? parameters = null,
        SqlTransaction? transaction = null
    )
    {
        SqlConnection conn = GetConnection();
        await conn.OpenAsync();

        SqlCommand cmd = new(query, conn, transaction);
        if (parameters is not null && parameters.Length > 0)
        {
            var paramsLst = parameters.Select(x => x.Map());
            cmd.Parameters.AddRange(paramsLst.ToArray());
        }
        SqlDataAdapter adapter = new(cmd);
        DataTable dt = new();
        adapter.Fill(dt);

        await conn.CloseAsync();

        return dt;
    }

    public async Task<int> ExecuteAsync(
        string query,
        AdoDotNetParameter[]? parameters = null,
        SqlTransaction? transaction = null
    )
    {
        SqlConnection conn = GetConnection();
        await conn.OpenAsync();

        SqlCommand cmd = new(query, conn, transaction);
        if (parameters is not null && parameters.Length > 0)
        {
            var paramsLst = parameters.Select(x => x.Map());
            cmd.Parameters.AddRange(paramsLst.ToArray());
        }
        int result = await cmd.ExecuteNonQueryAsync();
        await conn.CloseAsync();

        return result;
    }

    public class AdoDotNetParameter
    {
        public AdoDotNetParameter() { }

        public AdoDotNetParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public object Value { get; set; }
    }

    private SqlConnection GetConnection() => new(_connectionString);
}
