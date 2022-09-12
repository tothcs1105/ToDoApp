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

        [HttpGet("{taskId:int}")]

        public async Task<ActionResult<IEnumerable<ToDoTask>>> GetTask(int taskId)
        {
            var toDoTask = await _taskService.GetToDoTaskAsync(taskId);

            var mappedToDoTask = _mapper.Map<Api.DTOs.ToDoTask>(toDoTask);

            return Ok(mappedToDoTask);
        }

        [HttpPost]
        public async Task<ActionResult> AddTask([FromBody] NewToDoTask newTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTaskServiceModel = _mapper.Map<ToDoApp.DTOs.ToDoTask>(newTask);

            var createdTask = await _taskService.AddTaskAsync(newTaskServiceModel);

            return Ok(createdTask);  
        }


        [HttpDelete("{taskId:int}")]
        public async Task<ActionResult> DeleteTask(int taskId)
        {
            await _taskService.DeleteTaskAsync(taskId);

            return Ok();
        }
    }
}
