using ToDoApp.DataAccess.Interfaces;
using ToDoApp.DTOs;

namespace ToDoApp.DataAccess.FileSystem
{
    internal class ToDoTaskFileSystemRepository : IToDoTaskRepository
    {
        private FileInfo _destinationFile;

        public ToDoTaskFileSystemRepository(FileInfo destinationFile) => _destinationFile = destinationFile;

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
    }
}
