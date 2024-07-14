using System.Data.SqlClient;
using Newtonsoft.Json;
using static MTKDotNetCore.AdoDotNetCustomService.Shared.AdoDotNetService;

namespace MTKDotNetCore.AdoDotNetCustomService.Shared;

public static class DevCode
{
    public static string SerializeObject(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public static T DeserializeObject<T>(this string jsonStr)
    {
        return JsonConvert.DeserializeObject<T>(jsonStr)!;
    }

    public static SqlParameter Map(this AdoDotNetParameter parameter)
    {
        return new SqlParameter(parameter.Name, parameter.Value);
    }
}
