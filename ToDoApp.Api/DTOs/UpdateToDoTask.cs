using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Api.DTOs
{
    public class UpdateToDoTask
    {
        [Required]
        public int TaskId { get; set; }

        public string Description { get; set; }

        public TaskState State { get; set; }
    }
}
