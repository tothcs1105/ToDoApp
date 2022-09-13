using FluentAssertions;
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
        private ToDoTaskService _sut;

        public ToDoTaskServiceTests()
        {
            _loggerMock = new Mock<ILogger>();
            _taskRepositoryMock = new Mock<IToDoTaskRepository>();
            _validatorMock = new Mock<ValidatorBase<ToDoTask>>();
            _sut = new ToDoTaskService(_loggerMock.Object, _taskRepositoryMock.Object, _validatorMock.Object);
        }

        [Fact]
        public async void AddTaskAsync_ArgumentNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            ToDoTask toDoTask = null;

            //Act
            Func<Task> act = async () => await _sut.AddTaskAsync(toDoTask);

            //Assert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}