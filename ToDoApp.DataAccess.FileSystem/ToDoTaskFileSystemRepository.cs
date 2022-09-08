using ToDoApp.DataAccess.Interfaces;
using ToDoApp.DTOs;

namespace ToDoApp.DataAccess.FileSystem
{
    internal class ToDoTaskFileSystemRepository : IToDoTaskRepository
    {
        private FileInfo _destinationFile;
        private string _separator;

        public ToDoTaskFileSystemRepository(FileInfo destinationFile) { 
            _destinationFile = destinationFile ?? throw new ArgumentNullException(nameof(destinationFile));
            CreateFileIfNotExists();
        }

        public Task<ToDoTask> AddTaskAsync(ToDoTask task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskAsync(int taskId)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoTask> GetToDoTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDoTask>> GetToDoTasksAsync()
        {
            throw new NotImplementedException();
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

        private IEnumerable<string> ReadFile()
        {
            if (!_destinationFile.Exists)
            {
                return Enumerable.Empty<string>();
            }

            return System.IO.File.ReadAllLines(_destinationFile.FullName);
        }
    }
}
