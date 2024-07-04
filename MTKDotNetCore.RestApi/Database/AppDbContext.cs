using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.RestApi.Model;

namespace MTKDotNetCore.RestApi.Database
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
