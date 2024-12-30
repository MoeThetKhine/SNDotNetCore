namespace MTKDotNetCore.DapperCustomService.Shared;

public class DapperService
{
    public readonly string _connectionString;

    public DapperService(string connectionString)
    {
        _connectionString = connectionString;
    }

    #region Query

    public List<M> Query<M>(string query, object? param = null)
    {
        using IDbConnection db = GetConnection();
        var lst = db.Query<M>(query, param).ToList();
        return lst;
    }

    #endregion

    #region Execute

    public int Execute(string query, object? param = null)
    {
        using IDbConnection db = GetConnection();
        var result = db.Execute(query, param);
        return result;
    }

    #endregion

    #region QueryFirstOrDefault

    public M QueryFirstOrDefault<M>(string query, object? param = null)
    {
        using IDbConnection db = GetConnection();
        var item = db.Query<M>(query, param).FirstOrDefault();
        return item!;
    }

    #endregion

    #region QueryAsync

    public async Task<List<T>> QueryAsync<T>(
        string query,
        object? parameters = null,
        CommandType commandType = CommandType.Text
    )
    {
        using IDbConnection db = GetConnection();
        var lst = await db.QueryAsync<T>(query, parameters, commandType: commandType);
        return lst.ToList();
    }

    #endregion

    public async Task<T> QueryFirstOrDefaultAsync<T>(
        string query,
        object? parameters = null,
        CommandType commandType = CommandType.Text
    )
    {
        using IDbConnection db = GetConnection();
        var item = await db.QueryFirstOrDefaultAsync<T>(
            query,
            parameters,
            commandType: commandType
        );
        return item!;
    }

    public async Task<int> ExecuteAsync(string query, object parameters)
    {
        using IDbConnection db = GetConnection();
        return await db.ExecuteAsync(query, parameters);
    }

    private SqlConnection GetConnection() => new(_connectionString);
}
