using System.ComponentModel.DataAnnotations;

namespace BlogApi.Models;

public class Author
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Post> Posts { get; set; } = new List<Post>();
}