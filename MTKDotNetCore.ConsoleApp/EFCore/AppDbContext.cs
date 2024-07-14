#region using

using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.ConsoleApp.Dapper;

#endregion

namespace MTKDotNetCore.ConsoleApp.EFCore;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<BlogModel> Blogs { get; set; }
}
