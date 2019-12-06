using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Web.Domain.DailyRoute.CreateDailyRoute;
using EngineeringWork.Web.Domain.Drivers.CreateDriver;
using FluentAssertions;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.DriverTest
{
    public class CreateDriverCommandHandlerTest
    {
        [Fact]
        public async Task when_invoke_create_driver_command_handler_should_not_be_null()
        {
            var driverRepositoryMock = new Mock<IDriverRepository>();
            var nodeManagerMock = new Mock<INodeManager>();

            var driver = new Driver(Guid.NewGuid());
            driverRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync( () => null );

            var command = new CreateDriverCommand()
            {
                UserId = Guid.NewGuid(), 
                Vehicle = new CreateDriverCommand.DriverVehicle()
                {
                    Brand = "Bmw",
                    Name = "x5",
                    Seats = 5
                }
            };
           
            var commandHandler =  new CreateDriverCommandHandler(nodeManagerMock.Object, driverRepositoryMock.Object);
            var result = await commandHandler.Handle(command, CancellationToken.None);
            
            result.Should().NotBeNull();
        }
    }
}