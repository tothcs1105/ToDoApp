using ToDoApp.DataAccess.Interfaces;
using ToDoApp.DTOs;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Services
{
    internal class ToDoTaskService : IToDoTaskService
    {
        public ToDoTaskService(IToDoTaskRepository toDoTaskRepository)
        {

        }

        public Task<ToDoTask> AddTaskAsync(ToDoTask task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskAsync(int taskId)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoTask> UpdateTaskAsync(ToDoTask task)
        {
            throw new NotImplementedException();
        }
    }
}
