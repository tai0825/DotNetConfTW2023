using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrackingAndLazyLoading;

public class User
{
    [Key]
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FisrtName { get; set; }

    public virtual List<Post> Posts { get; set; }
    public DateOnly CreateAt { get; set; }

    //public ContactDetail Contact { get; set; }
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
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}
