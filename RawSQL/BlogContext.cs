namespace RawSQL;
public class BlogContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("")
            //.UseCosmos("https://localhost:8081/", "", "Blog")
            //.EnableSensitiveDataLogging()
            //.LogTo(Console.WriteLine, LogLevel.Information)
            ;
    }

    public DbSet<Post> Posts { get; set; }
}
