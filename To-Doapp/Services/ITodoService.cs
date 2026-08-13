using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        // List<Todo> GetAll();

        // Todo? GetById(int id);

        // Todo Add(Todo todo);

        // bool Update(int id, Todo todo);

        // bool Delete(int id);



        Task<List<Todo>> GetAllAsync();

        Task<Todo?> GetByIdAsync(int id);

        Task<Todo> CreateAsync(Todo todo);

        Task<bool> UpdateAsync(int id, Todo todo);

        Task<bool> DeleteAsync(int id);
    }
}