using System.ComponentModel.DataAnnotations;

namespace EF7;

public class User
{
    [Key]
    public int Id { get; set; }
    public string? FisrtName { get; set; }
    public string? LastName { get; set; }

    public ICollection<Post> Posts { get; set; }
}

public class Post
{
    [Key]
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Read { get; set; }
    public virtual User User { get; set; }
}