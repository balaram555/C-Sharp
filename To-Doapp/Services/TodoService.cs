using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly List<Todo> _todos = new()
        {
            new Todo
            {
                Id = 1,
                Title = "Learn C#",
                IsCompleted = true
            },

            new Todo
            {
                Id = 2,
                Title = "Learn Web API",
                IsCompleted = false
            }
        };

        private int _nextId = 3;

        public List<Todo> GetAll()
        {
            return _todos;
        }

        public Todo? GetById(int id)
        {
            return _todos.FirstOrDefault(t => t.Id == id);
        }

        public Todo Add(Todo todo)
        {
            todo.Id = _nextId++;

            _todos.Add(todo);

            return todo;
        }

        public bool Update(int id, Todo todo)
        {
            var existingTodo = _todos.FirstOrDefault(t => t.Id == id);

            if (existingTodo == null)
            {
                return false;
            }

            existingTodo.Title = todo.Title;
            existingTodo.IsCompleted = todo.IsCompleted;

            return true;
        }

        public bool Delete(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);

            if (todo == null)
            {
                return false;
            }

            _todos.Remove(todo);

            return true;
        }
    }
}