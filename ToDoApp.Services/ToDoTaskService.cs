using ToDoApp.DataAccess.Interfaces;
using ToDoApp.DTOs;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Services
{
    internal class ToDoTaskService : ServiceBase<ToDoTask>, IToDoTaskService
    {
        private IToDoTaskRepository _taskRepository;

        public ToDoTaskService(IToDoTaskRepository toDoTaskRepository, ValidatorBase<ToDoTask> validator) : base(validator)
        {
            _taskRepository = toDoTaskRepository ?? throw new ArgumentNullException(nameof(toDoTaskRepository));
        }

        public async Task<ToDoTask> AddTaskAsync(ToDoTask task)
        {
            _validator.Validate(task);

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
            var oldTask = await _taskRepository.GetToDoTaskAsync(task.Id);

            if(task.Description != null)
            {
                oldTask.Description = task.Description;
            }

            if (task.State.HasValue)
            {
                oldTask.State = task.State;
            }

            return await _taskRepository.UpdateTaskAsync(oldTask);
        }
    }
}
