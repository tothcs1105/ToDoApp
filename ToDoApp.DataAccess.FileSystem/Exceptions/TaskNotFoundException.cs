using System.Runtime.Serialization;

namespace ToDoApp.DataAccess.FileSystem.Exceptions
{
    [Serializable]
    internal class TaskNotFoundException : Exception
    {
        public TaskNotFoundException()
        {
        }

        public TaskNotFoundException(string? message) : base(message)
        {
        }

        public TaskNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TaskNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}