using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.DapperCustomerService.Model;

namespace MTKDotNetCore.DapperCustomerService.Database
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs {  get; set; }    
    }
}
