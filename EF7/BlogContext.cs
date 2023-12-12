namespace EF7;

public class BlogContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("")
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information)
            ;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
}
