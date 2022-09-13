using Serilog;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.DTOs;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Services
{
    internal class ToDoTaskService : ServiceBase<ToDoTask>, IToDoTaskService
    {
        private IToDoTaskRepository _taskRepository;
        private ILogger _logger;

        public ToDoTaskService(ILogger logger, IToDoTaskRepository toDoTaskRepository, ValidatorBase<ToDoTask> validator) : base(validator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _taskRepository = toDoTaskRepository ?? throw new ArgumentNullException(nameof(toDoTaskRepository));
        }

        public async Task<ToDoTask> AddTaskAsync(ToDoTask task)
        {
            _validator.Validate(task);

            task.State = TaskState.Uncompleted;

            var result = await _taskRepository.AddTaskAsync(task);

            _logger.Debug("Added new ToDo task {@task}", task);

            return result;
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            await _taskRepository.DeleteTaskAsync(taskId);

            _logger.Debug("Removed ToDo task {@task}", new { TaskId = taskId });
        }

        public async Task<ToDoTask> GetToDoTaskAsync(int id)
        {
            var result = await _taskRepository.GetToDoTaskAsync(id);

            _logger.Debug("Get ToDo task {@task}", result);

            return result;
        }

        public async Task<IEnumerable<ToDoTask>> GetToDoTasksAsync()
        {
            var result = await _taskRepository.GetToDoTasksAsync();

            _logger.Debug("Get All ToDo tasks");

            return result;
        }

        public async Task<ToDoTask> UpdateTaskAsync(ToDoTask task)
        {
            var originalTask = await _taskRepository.GetToDoTaskAsync(task.Id);

            if(task.Description != null)
            {
                originalTask.Description = task.Description;
            }

            if (task.State.HasValue)
            {
                originalTask.State = task.State;
            }

            var result = await _taskRepository.UpdateTaskAsync(originalTask);

            _logger.Debug("ToDo task updated {@task}", originalTask);

            return result;
        }
    }
}
