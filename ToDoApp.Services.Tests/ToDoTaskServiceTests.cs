using Moq;
using Serilog;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.DTOs;
using ToDoApp.Services.Interfaces;
using Xunit;

namespace ToDoApp.Services.Tests
{
    public class ToDoTaskServiceTests
    {
        private Mock<ILogger> _loggerMock;
        private Mock<IToDoTaskRepository> _taskRepositoryMock;
        private Mock<ValidatorBase<ToDoTask>> _validatorMock;

        public ToDoTaskServiceTests()
        {
            _loggerMock = new Mock<ILogger>();
            _taskRepositoryMock = new Mock<IToDoTaskRepository>();
            _validatorMock = new Mock<ValidatorBase<ToDoTask>>();
        }
    }
}