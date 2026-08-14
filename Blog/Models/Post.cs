namespace Blog.Models;

public class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public int AuthorId { get; set; }

    public Blog.Models.Author? Author { get; set; }
}