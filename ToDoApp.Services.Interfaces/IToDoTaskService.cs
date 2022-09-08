using ToDoApp.DTOs;

namespace ToDoApp.Services.Interfaces
{
    public interface IToDoTaskService
    {
        Task<ToDoTask> GetToDoTaskAsync(int id);
        Task<IEnumerable<ToDoTask>> GetToDoTasksAsync();
        Task<ToDoTask> AddTaskAsync(ToDoTask task);
        Task DeleteTaskAsync(int taskId);
        Task<ToDoTask> UpdateTaskAsync(ToDoTask task);
    }
}
