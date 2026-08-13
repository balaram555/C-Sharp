using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _context;
    //     private readonly List<Todo> _todos = new()
    //     {
    //         new Todo
    //         {
    //             Id = 1,
    //             Title = "Learn C#",
    //             IsCompleted = true
    //         },

    //         new Todo
    //         {
    //             Id = 2,
    //             Title = "Learn Web API",
    //             IsCompleted = false
    //         }
    //     };

    //     private int _nextId = 3;

    //     public List<Todo> GetAll()
    //     {
    //         return _todos;
    //     }

    //     public Todo? GetById(int id)
    //     {
    //         return _todos.FirstOrDefault(t => t.Id == id);
    //     }

    //     public Todo Add(Todo todo)
    //     {
    //         todo.Id = _nextId++;

    //         _todos.Add(todo);

    //         return todo;
    //     }

    //     public bool Update(int id, Todo todo)
    //     {
    //         var existingTodo = _todos.FirstOrDefault(t => t.Id == id);

    //         if (existingTodo == null)
    //         {
    //             return false;
    //         }

    //         existingTodo.Title = todo.Title;
    //         existingTodo.IsCompleted = todo.IsCompleted;

    //         return true;
    //     }

    //     public bool Delete(int id)
    //     {
    //         var todo = _todos.FirstOrDefault(t => t.Id == id);

    //         if (todo == null)
    //         {
    //             return false;
    //         }

    //         _todos.Remove(todo);

    //         return true;
    //     }

        public TodoService(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<Todo> CreateAsync(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> UpdateAsync(int id, Todo todo)
        {
            var existingTodo = await _context.Todos.FindAsync(id);

            if (existingTodo == null)
            {
                return false;
            }

            existingTodo.Title = todo.Title;
            existingTodo.IsCompleted = todo.IsCompleted;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
            {
                return false;
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}