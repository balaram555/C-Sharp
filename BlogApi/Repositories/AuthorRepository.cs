using BlogApi.Data;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _context.Authors
            .Include(a => a.Posts)
            .ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _context.Authors
            .Include(a => a.Posts)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Author> CreateAsync(Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();

        return author;
    }

    public async Task<bool> UpdateAsync(int id, Author author)
    {
        var existing = await _context.Authors.FindAsync(id);

        if (existing == null)
            return false;

        existing.Name = author.Name;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var author = await _context.Authors.FindAsync(id);

        if (author == null)
            return false;

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();

        return true;
    }
}