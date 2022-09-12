using ToDoApp.DataAccess.Interfaces;
using ToDoApp.DTOs;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Services
{
    internal class ToDoTaskService : IToDoTaskService
    {
        private IToDoTaskRepository _taskRepository;

        public ToDoTaskService(IToDoTaskRepository toDoTaskRepository)
        {
            _taskRepository = toDoTaskRepository ?? throw new ArgumentNullException(nameof(toDoTaskRepository));
        }

        public async Task<ToDoTask> AddTaskAsync(ToDoTask task)
        {
            task.State = TaskState.Uncompleted;

            return await _taskRepository.AddTaskAsync(task);
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            await _taskRepository.DeleteTaskAsync(taskId);
        }

        public async Task<ToDoTask> GetToDoTaskAsync(int id)
        {
            return await _taskRepository.GetToDoTaskAsync(id);
        }

        public async Task<IEnumerable<ToDoTask>> GetToDoTasksAsync()
        {
            return await _taskRepository.GetToDoTasksAsync();
        }

        public async Task<ToDoTask> UpdateTaskAsync(ToDoTask task)
        {
            return await _taskRepository.UpdateTaskAsync(task);
        }
    }
}
