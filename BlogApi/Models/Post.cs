using System.ComponentModel.DataAnnotations;

namespace BlogApi.Models;

public class Post
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    public int AuthorId { get; set; }

    public Author? Author { get; set; }
}