using Microsoft.Extensions.DependencyInjection;
using ToDoApp.DataAccess.Interfaces;

namespace ToDoApp.DataAccess.FileSystem
{
    public static class RegisterRepositories
    {
        public static IServiceCollection AddRepositoryRegistrations(this IServiceCollection serviceCollection, FileInfo filePath)
        {
            serviceCollection.AddScoped<IToDoTaskRepository>(provider => new ToDoTaskFileSystemRepository(filePath));

            return serviceCollection;
        }
    }
}
