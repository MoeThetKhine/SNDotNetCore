#region using 

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion




namespace MTKDotNetCore.ConsoleApp.EFCore
{
    [Table("Tbl_Blog")]
    public class BlogModel
    {
        [Key]
        public long BlogId {  get; set; }
        public string BlogTitle {  get; set; }
        public string BlogAuthor {  get; set; } 
        public string BlogContent {  get; set; }
        public bool IsActive {  get; set; }
    }
}
