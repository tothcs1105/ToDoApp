using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Services
{
    public static class RegisterServices
    {
        public static IServiceCollection AddToDoAppServiceRegistrations(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IToDoTaskService, ToDoTaskService>();

            return serviceCollection;
        }
    }
}
