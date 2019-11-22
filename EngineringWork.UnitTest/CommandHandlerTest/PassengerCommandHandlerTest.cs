using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Infrastructure.CommandHandlers.PassengerHandler;
using EngineeringWork.Infrastructure.Commands.Passenger;
using EngineeringWork.Infrastructure.QueryHandlers.PassengerHandler;
using FluentAssertions;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.CommandHandlerTest
{
    public class PassengerCommandHandlerTest
    {

        [Fact]
        public async Task create_passenger_handler_should_not_be_null()
        {
            //var passengerRepositoryMock = new Mock<IPassengerRepository>();
            //var routeRepositoryMock = new Mock<IDailyRouteRepository>();
            //var nodeManagerMock = new Mock<INodeManager>();
            
            //var passengerHandler = new PassengerHandler(passengerRepositoryMock.Object, routeRepositoryMock.Object, nodeManagerMock.Object);
            //routeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
            //    .ReturnsAsync( new DailyRoute());
            
            //var result = await passengerHandler.Handle(new CreatePassengerCommand() { UserId = Guid.NewGuid(), Adress = new CreatePassengerCommand.PassengerAdres()}, CancellationToken.None);
            //result.Should().NotBeNull();
        }
        
        [Fact]
        public async Task remove_passenger_from_route_handler_should_not_be_null()
        {
            //var passengerRepositoryMock = new Mock<IPassengerRepository>();
            //var routeRepositoryMock = new Mock<IDailyRouteRepository>();
            //var nodeManagerMock = new Mock<INodeManager>();
            //routeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(new DailyRoute());
            
            //var passengerHandler = new PassengerHandler(passengerRepositoryMock.Object, routeRepositoryMock.Object, nodeManagerMock.Object);
            //var result = await passengerHandler.Handle(new RemovePassengerFromRouteCommand() { UserId = Guid.NewGuid(), RouteId = Guid.NewGuid() }, CancellationToken.None);
            //result.Should().NotBeNull();
        }
        
        [Fact]
        public async Task add_passenger_to_route_handler_should_not_be_null()
        {
            //var passengerRepositoryMock = new Mock<IPassengerRepository>();
            //var routeRepositoryMock = new Mock<IDailyRouteRepository>();
            //var nodeManagerMock = new Mock<INodeManager>();
            //routeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
            //    .ReturnsAsync(new DailyRoute());
            
            //var passengerHandler = new PassengerHandler(passengerRepositoryMock.Object, routeRepositoryMock.Object, nodeManagerMock.Object);
            //var result = await passengerHandler.Handle(new AddPassengerToRouteCommand() { RouteId = Guid.NewGuid(), Latitude = 12, Longitude = 123, UserId = Guid.NewGuid() }, CancellationToken.None);
            //result.Should().NotBeNull();
        }
    }
}