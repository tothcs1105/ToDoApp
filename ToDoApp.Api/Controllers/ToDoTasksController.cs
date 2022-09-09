using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Api.DTOs;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTasksController : ControllerBase
    {
        private IMapper _mapper;
        private IToDoTaskService _taskService;

        public ToDoTasksController(IMapper mapper, IToDoTaskService taskService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ToDoTask>>> GetTasks()
        {
            var toDoList = await _taskService.GetToDoTasksAsync();

            var mappedToDoList = _mapper.Map<IEnumerable<Api.DTOs.ToDoTask>>(toDoList);

            return Ok(mappedToDoList);
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<IEnumerable<ToDoTask>>> GetTask(int id)
        {
            var toDoTask = await _taskService.GetToDoTaskAsync(id);

            var mappedToDoTask = _mapper.Map<Api.DTOs.ToDoTask>(toDoTask);

            return Ok(mappedToDoTask);
        }


    }
}
