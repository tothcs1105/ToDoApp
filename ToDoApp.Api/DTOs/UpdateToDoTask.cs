using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Api.DTOs
{
    public class UpdateToDoTask
    {
        [Required]
        public int Id { get; set; }

        public string? Description { get; set; }

        public TaskState? State { get; set; }
    }
}
