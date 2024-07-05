using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.AdoDotNetWebApi.Model;
using MTKDotNetCore.AdoDotNetWebApi.Database;

namespace MTKDotNetCore.AdoDotNetWebApi.Database
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(ConnnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
 