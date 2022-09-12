using Serilog;
using System.Text.Json.Serialization;
using ToDoApp.Api.Mappings;
using ToDoApp.Common;
using ToDoApp.DataAccess.FileSystem;
using ToDoApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(config =>
{
    config.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(c =>
{
    c.AddProfile<ApiDtoMappings>();

});

builder.Services.AddToDoAppServiceRegistrations();
builder.Services.AddRepositoryRegistrations(new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ToDoApp.json")));
builder.Services.AddScoped<ISerializer, JsonSerializer>();

builder.Host.UseSerilog((hostContext, services, configuration) =>
    configuration.ReadFrom.Configuration(builder.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
