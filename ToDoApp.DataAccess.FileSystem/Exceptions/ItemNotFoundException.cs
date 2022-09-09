using System.Runtime.Serialization;

namespace ToDoApp.DataAccess.FileSystem.Exceptions
{
    [Serializable]
    internal class ItemNotFoundException : Exception
    {
        public ItemNotFoundException()
        {
        }

        public ItemNotFoundException(string? message) : base(message)
        {
        }

        public ItemNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}