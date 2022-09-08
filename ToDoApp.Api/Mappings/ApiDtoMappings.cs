using AutoMapper;
using ToDoApp.DTOs;

namespace ToDoApp.Api.Mappings
{
    public class ApiDtoMappings : Profile
    {
        public ApiDtoMappings()
        {
            CreateMap<ToDoTask, Api.DTOs.ToDoTask>();
            CreateMap<ToDoTask, Api.DTOs.TaskState>();
        }
    }
}
