namespace MTKDotNetCore.AdoDotNetCustomService.Shared;

public static class DevCode
{
    #region SerializeObject

    public static string SerializeObject(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    #endregion

    public static T DeserializeObject<T>(this string jsonStr)
    {
        return JsonConvert.DeserializeObject<T>(jsonStr)!;
    }

    public static SqlParameter Map(this AdoDotNetParameter parameter)
    {
        return new SqlParameter(parameter.Name, parameter.Value);
    }
}
