using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.AdoDotNetWebApi.Model;
using MTKDotNetCore.EFCoreRestApi.Database;

namespace MTKDotNetCore.AdoDotNetWebApi.Database
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
