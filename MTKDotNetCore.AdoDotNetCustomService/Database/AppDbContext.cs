using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.AdoDotNetCustomService.Model;

namespace MTKDotNetCore.AdoDotNetCustomService.Database
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blog { get; set; }
    }

}
