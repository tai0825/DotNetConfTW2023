namespace TrackingAndLazyLoading;

public class BlogContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("")
            //.UseCosmos("https://localhost:8081/", "", "Blog")
            .EnableSensitiveDataLogging()
            //.LogTo(Console.WriteLine, LogLevel.Information)
            ;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Post>()
            .Navigation(p => p.User)
            .EnableLazyLoading(false);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
}