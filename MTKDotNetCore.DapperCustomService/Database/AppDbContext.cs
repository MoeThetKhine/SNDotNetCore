namespace MTKDotNetCore.DapperCustomService.Database;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<BlogModel> Blog { get; set; }
}
