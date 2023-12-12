using System.ComponentModel.DataAnnotations;

namespace JsonColumn;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string UserName { get; set; }

    public List<Post> Posts { get; set; }

    //public ContactDetail Contact { get; set; }
}

public class Post
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int Read { get; set; }
    public virtual User User { get; set; }
}
