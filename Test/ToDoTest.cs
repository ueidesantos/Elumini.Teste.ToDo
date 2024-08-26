using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Elumini.Test.ToDo.Application.Ports;
using Elumini.Test.ToDo.Application.Services;
using Elumini.Teste.ToDo.Test.Mocks;
using Microsoft.Data.SqlClient;
using Moq;
using System.Data.Common;

namespace Elumini.Teste.ToDo.Test
{
    public class ToDoTest
    {

        [Fact]
        public async Task CreateToDo_WithGenericException_SholdBeFail()
        {
            //Arrange
            var toDoMock = ToDoMock.BuildMock();
            Mock<IToDoRepository> toDoRepositoryMock = new Mock<IToDoRepository>();
            Mock<ILogger<ToDoService>> loggerMock = new Mock<ILogger<ToDoService>>();
            Mock<IMapper> mapper = new Mock<IMapper>();
            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            Mock<IToDoQueuePublisher> toDoQueuePublisher = new Mock<IToDoQueuePublisher>();

            configuration.Setup(x => x.GetSection(It.IsAny<string>()).Value).Returns("0");
            toDoRepositoryMock.Setup(x => x.Add(It.IsAny<Elumini.Test.ToDo.Domain.ToDo>())).Throws(new Exception());
            var toDoService = new ToDoService(
                toDoRepositoryMock.Object,
                loggerMock.Object,
                mapper.Object,
                configuration.Object,
                toDoQueuePublisher.Object);

            //Act
            Action act = () => toDoService.Add(toDoMock);

            //Assert
            //act Should().ThrowExactly<ArgumentNullException>().WithMessage("*userId*");
            toDoRepositoryMock.Verify(x => x.Add(It.IsAny<Elumini.Test.ToDo.Domain.ToDo>()), Times.Once);

        }
    }
}
