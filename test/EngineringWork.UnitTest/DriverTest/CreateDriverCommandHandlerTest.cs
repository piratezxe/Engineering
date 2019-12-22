using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Web.Application;
using EngineeringWork.Web.Application.DailyRoute.GetDailyRoute;
using EngineeringWork.Web.Application.Drivers.CreateDriver;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.DriverTest
{
    public class CreateDriverCommaqndHandlerTest
    {
        [Fact]
        public async Task when_invoke_create_driver_and_driver_not_exist_command_handler_should_not_be_null()
        {
            var driverRepositoryMock = new Mock<IDriverRepository>();
            var nodeManagerMock = new Mock<INodeManager>();

            driverRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync( () => null);

            var command = new CreateDriverCommand("123123")
            {
                UserId = Guid.NewGuid()
            };
           
            var commandHandler =  new CreateDriverCommandHandler(nodeManagerMock.Object, driverRepositoryMock.Object);
            var result = await commandHandler.Handle(command, CancellationToken.None);
            
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task when_invoke_create_driver_command_handler_and_driver_exist_should_throw_exception()
        {
            var driverRepositoryMock = new Mock<IDriverRepository>();
            var nodeManagerMock = new Mock<INodeManager>();
            
            var driver = new Driver(Guid.NewGuid(), "123123123123");

            driverRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(() => driver);
            
            var command = new CreateDriverCommand("123123")
            {
                UserId = Guid.NewGuid()
            };

            var commandHandler =
                new CreateDriverCommandHandler(nodeManagerMock.Object, driverRepositoryMock.Object);

            Func<Task> act = async () => await commandHandler.Handle(command, CancellationToken.None);

            act.Should().Throw<Exception>();
        }
    }
}