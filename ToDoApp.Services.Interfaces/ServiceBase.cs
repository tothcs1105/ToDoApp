namespace ToDoApp.Services.Interfaces
{
    public abstract class ServiceBase<T> where T : class
    {
        protected ValidatorBase<T> _validator;

        public ServiceBase(ValidatorBase<T> validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }
    }
}
