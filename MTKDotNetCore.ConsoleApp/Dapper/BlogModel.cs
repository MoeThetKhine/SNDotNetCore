#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion



namespace MTKDotNetCore.ConsoleApp.Dapper;

public class BlogModel
{
    public long BlogId {  get; set; }
    public string BlogTitle {  get; set; }
    public string BlogAuthor {  get; set; }
    public string BlogContent {  get; set; }
}
//public record BlogEntity(int BlogId, string BlogTitle,string BlogAuthor,string BlogContent);
