#region using 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace MTKDotNetCore.ConsoleApp.EFCore
{
    public class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();

        #region Run
        public void Run()
        {
            Read();
            // Edit(2);
            // Edit(22);
            // Create("Title created", "Author created", "Content created");
            // Update(14,"Title updated", "Author updated", "Content updated");
            Delete(14);
        }

        #endregion

        private void Read()
        {
            var lst = db.Blogs.ToList();
            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("_________________________");
            }
        }
        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x=>x.BlogId == id);
            //foreach(BlogModel x in db.Blogs)
            //{
            //    if (x.BlogId == id)
            // }
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("____________________");
                

        }

        private void Create(string title,string author,string content)
        {
            var item = new BlogModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            db.Blogs.Add(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Creating Successful" : "Creating Fail";
            Console.WriteLine(message);
        }

        private void Update(int id ,string title,string author,string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id); // id exists or not

            if(item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            item.BlogTitle = title; 
            item.BlogAuthor = author;
            item.BlogContent = content;

            int result = db.SaveChanges();

            string message = result > 0 ? "Updating Successful" : "Updating Fail";
            Console.WriteLine(message);
             
        }

        private void Delete(int id)
        {
           
            var item =  db.Blogs.FirstOrDefault(x=> x.BlogId == id);
            if(item is null)
            {
                Console.WriteLine("No Data Found");
            }
            db.Blogs.Remove(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Deleting Successful" : "Deleting Fail";
            Console.WriteLine(message);

        }

    }
}
