using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.DapperCustomService.Model;

namespace MTKDotNetCore.DapperCustomService.Database
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
