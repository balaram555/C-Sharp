using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PostsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        var posts = await _context.Posts
            .Include(p => p.Author)
            .ToListAsync();

        return Ok(posts);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(Blog.Models.Post post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return Ok(post);
    }
}