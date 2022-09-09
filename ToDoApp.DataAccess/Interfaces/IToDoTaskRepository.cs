using ToDoApp.DTOs;

namespace ToDoApp.DataAccess.Interfaces
{
    public interface IToDoTaskRepository
    {
        Task<ToDoTask> GetToDoTaskAsync(int id);
        Task<IEnumerable<ToDoTask>> GetToDoTasksAsync();
        Task<ToDoTask> AddTaskAsync(ToDoTask task);
        Task DeleteTaskAsync(int id);
        Task<ToDoTask> UpdateTaskAsync(ToDoTask task);
    }
}
