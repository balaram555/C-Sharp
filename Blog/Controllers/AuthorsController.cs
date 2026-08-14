using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthorsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthors()
    {
        var authors = await _context.Authors
            .Include(a => a.Posts)
            .ToListAsync();

        return Ok(authors);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor(Blog.Models.Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();

        return Ok(author);
    }
}