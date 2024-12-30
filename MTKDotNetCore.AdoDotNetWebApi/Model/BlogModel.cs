namespace MTKDotNetCore.AdoDotNetWebApi.Model;

#region BlogModel

public class BlogModel
{
    public long BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
    public bool IsActive { get; set; }
}

#endregion