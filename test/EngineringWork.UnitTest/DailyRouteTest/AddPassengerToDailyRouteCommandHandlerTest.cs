using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Web.Domain.DailyRoute.AddPassengerToRoute;
using FluentAssertions;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.DailyRouteTest
{
    public class AddPassengerToDailyRouteCommandHandlerTest 
    {
        [Fact]
        public async Task add_passenger_to_route_handler_should_not_be_null()
        {
            var passengerRepositoryMock = new Mock<IPassengerRepository>();
            var routeRepositoryMock = new Mock<IDailyRouteRepository>();
            var nodeManagerMock = new Mock<INodeManager>();
            
            var startNode = Node.Create("asdas", 21, 22);
            var endNode = Node.Create("asdas", 21, 22);

            var route = Route.Create(startNode, endNode);
            var moneyValue = new MoneyValue(13, "Pln");
            
            var dailyRoute =  DailyRoute.CreateDailyRoute(DateTime.UtcNow, DateTime.UtcNow, route, Guid.NewGuid(), 5, moneyValue);
            
            routeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(dailyRoute);
            
            var passengerHandler = new AddPassengerToRouteCommandHandler(passengerRepositoryMock.Object, routeRepositoryMock.Object, nodeManagerMock.Object);
            var result = await passengerHandler.Handle(new AddPassengerToRouteCommand() { RouteId = Guid.NewGuid(), Latitude = 12, Longitude = 123, UserId = Guid.NewGuid() }, CancellationToken.None);
            result.Should().NotBeNull();
        }
    }
}