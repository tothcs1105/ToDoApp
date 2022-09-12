using Microsoft.Extensions.DependencyInjection;
using ToDoApp.DTOs;
using ToDoApp.Services.Interfaces;
using ToDoApp.Services.Validators;

namespace ToDoApp.Services
{
    public static class RegisterServices
    {
        public static IServiceCollection AddToDoAppServiceRegistrations(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IToDoTaskService, ToDoTaskService>();
            serviceCollection.AddSingleton<ValidatorBase<ToDoTask>, ToDoTaskValidator>();

            return serviceCollection;
        }
    }
}
