using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCore.ConsoleApp.EFCore
{
    public class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();

        public void Run()
        {
            Read();
        }
        private void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.Blogs.ToList();
            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

    }
}
