using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Api.DTOs
{
    public class NewToDoTask
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title field cannot be empty!")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }
    }
}
