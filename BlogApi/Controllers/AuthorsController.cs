using BlogApi.Models;
using BlogApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorRepository _repository;

    public AuthorsController(IAuthorRepository repository)
    {
        _repository = repository;
    }

    // GET: api/Authors
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var authors = await _repository.GetAllAsync();

        return Ok(authors);
    }

    // GET: api/Authors/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var author = await _repository.GetByIdAsync(id);

        if (author == null)
            return NotFound();

        return Ok(author);
    }

    // POST: api/Authors
    [HttpPost]
    public async Task<IActionResult> Create(Author author)
    {
        var createdAuthor = await _repository.CreateAsync(author);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdAuthor.Id },
            createdAuthor
        );
    }

    // PUT: api/Authors/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Author author)
    {
        var updated = await _repository.UpdateAsync(id, author);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/Authors/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repository.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}