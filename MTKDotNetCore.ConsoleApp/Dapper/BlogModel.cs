namespace MTKDotNetCore.ConsoleApp.Dapper;

#region BlogModel

public class BlogModel
{
    public long BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}
//public record BlogEntity(int BlogId, string BlogTitle,string BlogAuthor,string BlogContent);

#endregion
