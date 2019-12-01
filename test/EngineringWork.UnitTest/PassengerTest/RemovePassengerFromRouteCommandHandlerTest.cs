using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Web.Domain.DailyRoute.RemovePassengerFromRoute;
using FluentAssertions;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.PassengerTest
{
    public class RemovePassengerFromRouteCommandHandlerTest
    {
        [Fact]
        public async Task remove_passenger_from_route_handler_should_not_be_null()
        {
            var passengerRepositoryMock = new Mock<IPassengerRepository>();
            var routeRepositoryMock = new Mock<IDailyRouteRepository>();
            var nodeManagerMock = new Mock<INodeManager>();
            
            var startNode = Node.Create("asdas", 21, 22);
            var endNode = Node.Create("asdas", 21, 22);

            var route = Route.Create(startNode, endNode);
            var moneyValue = new MoneyValue(13, "Pln");
            
            var dailyRoute =  DailyRoute.CreateDailyRoute(DateTime.UtcNow, DateTime.UtcNow, route, Guid.NewGuid(), 5, moneyValue);
            
            routeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(dailyRoute);
            
            var passengerHandler = new RemovePassengerFromRouteCommandHandler(passengerRepositoryMock.Object, routeRepositoryMock.Object, nodeManagerMock.Object);
            var result = await passengerHandler.Handle(new RemovePassengerFromRouteCommand() { UserId = Guid.NewGuid(), RouteId = Guid.NewGuid() }, CancellationToken.None);
            result.Should().NotBeNull();
        }
    }
}