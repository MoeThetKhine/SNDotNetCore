﻿namespace MTKDotNetCore.ConsoleApp.EFCore;

#region Table Blog

[Table("Tbl_Blog")]
public class BlogModel
{
    [Key]
    public long BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
    public bool IsActive { get; set; }
}

#endregion