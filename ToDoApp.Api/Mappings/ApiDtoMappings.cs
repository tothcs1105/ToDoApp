using AutoMapper;
using ToDoApp.DTOs;

namespace ToDoApp.Api.Mappings
{
    public class ApiDtoMappings : Profile
    {
        public ApiDtoMappings()
        {
            ToApiDto();
            ToBusinessDto();
        }

        private void ToApiDto()
        {
            CreateMap<ToDoTask, Api.DTOs.ToDoTask>();
            CreateMap<ToDoTask, Api.DTOs.TaskState>();
        }

        private void ToBusinessDto()
        {
            CreateMap<Api.DTOs.NewToDoTask, ToDoTask>();
            CreateMap<Api.DTOs.UpdateToDoTask, ToDoTask>();
        }
    }
}
