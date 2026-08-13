using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/todo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoService.GetAllAsync();

            return Ok(todos);
        }

        // GET: api/todo/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _todoService.GetByIdAsync(id);

            if (todo == null)
            {
                return NotFound(new
                {
                    message = "Todo not found"
                });
            }

            return Ok(todo);
        }

        // POST: api/todo
        [HttpPost]
        public async Task<IActionResult> Create(Todo todo)
        {
            var createdTodo = await _todoService.CreateAsync(todo);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdTodo.Id },
                createdTodo
            );
        }

        // PUT: api/todo/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Todo todo)
        {
            var updated = await _todoService.UpdateAsync(id, todo);

            if (!updated)
            {
                return NotFound(new
                {
                    message = "Todo not found"
                });
            }

            return Ok(new
            {
                message = "Todo updated successfully"
            });
        }

        // DELETE: api/todo/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _todoService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Todo not found"
                });
            }

            return Ok(new
            {
                message = "Todo deleted successfully"
            });
        }
    }
}