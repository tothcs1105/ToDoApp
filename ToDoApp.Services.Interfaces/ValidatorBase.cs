using ToDoApp.Services.Interfaces.Exceptions;

namespace ToDoApp.Services.Interfaces
{
    public abstract class ValidatorBase<T> where T : class
    {
        public IDictionary<string, string> ModelErrors { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public void Validate(T obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            ValidateModel(obj);

            if (ModelErrors.Any())
            {
                throw new ModelValidationException(ModelErrors);
            }
        }

        protected abstract void ValidateModel(T obj);
    }
}
