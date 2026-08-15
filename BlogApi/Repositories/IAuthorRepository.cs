using BlogApi.Models;

namespace BlogApi.Repositories;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAsync();
    Task<Author?> GetByIdAsync(int id);
    Task<Author> CreateAsync(Author author);
    Task<bool> UpdateAsync(int id, Author author);
    Task<bool> DeleteAsync(int id);
}