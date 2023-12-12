using System.ComponentModel.DataAnnotations;

namespace RawSQL;

public class Post
{
    [Key]
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Read { get; set; }
}

public class SampleSelect
{
    public string Title { get; set; }
    public string Content { get; set; }
}