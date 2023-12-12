namespace JsonColumn;

public class BlogContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("")
            //.UseCosmos("https://localhost:8081/", "", "Blog")
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information)
            ;
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().OwnsMany(u => u.Posts, p =>
        {
            p.ToJson("Posts");
        });
    }
}