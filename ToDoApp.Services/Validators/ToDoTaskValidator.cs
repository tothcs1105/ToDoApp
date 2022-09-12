using ToDoApp.DTOs;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Services.Validators
{
    internal class ToDoTaskValidator : ValidatorBase<ToDoTask>
    {
        protected override void ValidateModel(ToDoTask obj)
        {
            if(string.IsNullOrWhiteSpace(obj.Title))
            {
                this.ModelErrors.Add("Title", "Title cannot be empty!");
            }
        }
    }
}
