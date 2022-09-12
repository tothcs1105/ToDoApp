namespace ToDoApp.Services.Interfaces.Exceptions
{
    public class ModelValidationException : Exception
    {
        public IDictionary<string, string> Errors { get; private set; } = new Dictionary<string, string>();

        public ModelValidationException(IDictionary<string, string> errors)
        {
            this.Errors = errors ?? throw new ArgumentNullException(nameof(errors));
        }
    }
}
