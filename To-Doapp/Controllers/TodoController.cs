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
        public IActionResult GetAll()
        {
            var todos = _todoService.GetAll();

            return Ok(todos);
        }

        // GET: api/todo/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _todoService.GetById(id);

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
        public IActionResult Create(Todo todo)
        {
            var createdTodo = _todoService.Add(todo);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdTodo.Id },
                createdTodo
            );
        }

        // PUT: api/todo/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Todo todo)
        {
            var updated = _todoService.Update(id, todo);

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
        public IActionResult Delete(int id)
        {
            var deleted = _todoService.Delete(id);

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