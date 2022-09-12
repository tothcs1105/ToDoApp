using ToDoApp.Common;
using ToDoApp.DataAccess.Exceptions;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.DTOs;

namespace ToDoApp.DataAccess.FileSystem
{
    internal class ToDoTaskFileSystemRepository : FileSystemRepositoryBase<ToDoTask, int>, IToDoTaskRepository
    {
        private Func<ToDoTask, int> KeySelector = toDoTask => toDoTask.Id;

        public ToDoTaskFileSystemRepository(ISerializer serializer, FileInfo destinationFile) : base(destinationFile, serializer) { 
            _destinationFile = destinationFile ?? throw new ArgumentNullException(nameof(destinationFile));
            InitializeFile(Enumerable.Empty<ToDoTask>());
        }

        public Task<ToDoTask> AddTaskAsync(ToDoTask task)
        {
            var toDoList = ReadFile(KeySelector);

            task.Id = toDoList.Count > 0 ? toDoList.Keys.Max() + 1 : 1;

            toDoList.Add(task.Id, task);

            WriteFile(toDoList.Values.AsEnumerable());

            return Task.FromResult(task);
        }

        public Task DeleteTaskAsync(int id)
        {
            var toDoList = ReadFile(KeySelector);

            if (toDoList.ContainsKey(id))
            {
                toDoList.Remove(id);

                WriteFile(toDoList.Values.AsEnumerable());

                return Task.CompletedTask;
            }

            throw new ItemNotFoundException($"Can't delete task with id {id}, because it was not found in the DB.");
        }

        public Task<ToDoTask> GetToDoTaskAsync(int id)
        {
            var toDoList = ReadFile(KeySelector);

            if(toDoList.TryGetValue(id, out var toDoTask))
            {
                return Task.FromResult(toDoTask);
            }

            throw new ItemNotFoundException($"Task with the id {id} was not found in the DB.");
        }

        public Task<IEnumerable<ToDoTask>> GetToDoTasksAsync()
        {
            return Task.FromResult(ReadFile(KeySelector).Values.AsEnumerable());
        }

        public Task<ToDoTask> UpdateTaskAsync(ToDoTask task)
        {
            var toDoList = ReadFile(KeySelector);

            if(toDoList.TryGetValue(task.Id, out var oldTask))
            {
                oldTask.Description = task.Description;
                oldTask.State = task.State;

                WriteFile(toDoList.Values.AsEnumerable());
            }

            throw new ItemNotFoundException($"Task with the id {task.Id} was not found int the DB.");
        }
    }
}
