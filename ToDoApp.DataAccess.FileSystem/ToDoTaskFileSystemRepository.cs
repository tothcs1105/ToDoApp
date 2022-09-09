using ToDoApp.Common;
using ToDoApp.DataAccess.FileSystem.Exceptions;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.DTOs;

namespace ToDoApp.DataAccess.FileSystem
{
    internal class ToDoTaskFileSystemRepository : IToDoTaskRepository
    {
        private FileInfo _destinationFile;
        private ISerializer _serializer;

        public ToDoTaskFileSystemRepository(ISerializer serializer, FileInfo destinationFile) { 
            _destinationFile = destinationFile ?? throw new ArgumentNullException(nameof(destinationFile));
            CreateFileIfNotExists();
        }

        public Task<ToDoTask> AddTaskAsync(ToDoTask task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskAsync(int id)
        {
            var toDoList = ReadFile();

            if (toDoList.ContainsKey(id))
            {
                toDoList.Remove(id);

                WriteFile(toDoList.Values.AsEnumerable());

                return Task.CompletedTask;
            }

            throw new TaskNotFoundException($"Can't delete task with id {id}. Because it was not found in the DB.");
        }

        public Task<ToDoTask> GetToDoTaskAsync(int id)
        {
            var toDoList = ReadFile();

            if(toDoList.TryGetValue(id, out var toDoTask))
            {
                return Task.FromResult(toDoTask);
            }

            throw new TaskNotFoundException($"Task with the id {id} was not found in the DB.");
        }

        public Task<IEnumerable<ToDoTask>> GetToDoTasksAsync()
        {
            return Task.FromResult(ReadFile().Values.AsEnumerable());
        }

        public Task<ToDoTask> UpdateTaskAsync(ToDoTask task)
        {
            throw new NotImplementedException();
        }

        private void CreateFileIfNotExists()
        {
            if (!_destinationFile.Exists)
            {
                _destinationFile.Create();
            }
        }

        private IDictionary<int, ToDoTask> ReadFile()
        {
            var toDoList = _serializer.Deserialize<IEnumerable<ToDoTask>>(System.IO.File.ReadAllText(_destinationFile.FullName));

            return toDoList.ToDictionary(task => task.Id, task => task);
        }

        private void WriteFile(IEnumerable<ToDoTask> toDoList)
        {
            var serializedToDoList = _serializer.Serialize(toDoList);

            File.WriteAllText(_destinationFile.FullName, serializedToDoList);
        }
    }
}
