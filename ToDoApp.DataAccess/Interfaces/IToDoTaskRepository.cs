using ToDoApp.DTOs;

namespace ToDoApp.DataAccess.Interfaces
{
    public interface IToDoTaskRepository
    {
        Task AddTaskAsync(ToDoTask task);
        Task DeleteTaskAsync(int taskId);
        Task UpdateTaskAsync(ToDoTask task);
    }
}
