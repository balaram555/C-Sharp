using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        List<Todo> GetAll();

        Todo? GetById(int id);

        Todo Add(Todo todo);

        bool Update(int id, Todo todo);

        bool Delete(int id);
    }
}