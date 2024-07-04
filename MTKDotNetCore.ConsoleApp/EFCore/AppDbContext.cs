using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.ConsoleApp.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCore.ConsoleApp.EFCore
{
    public class AppDbContext: DbContext
    {
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
