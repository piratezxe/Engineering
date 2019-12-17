using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Web.Application.DailyRoute.RemovePassengerFromRoute;
using FluentAssertions;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.DailyRouteTest
{
    public class RemovePassengerFromDailyRouteCommandHandlerTest
    {
        [Fact]
        public async Task when_invoke_remove_passenger_from_daily_route_handler_should_not_be_null()
        {
            var dailyRouteRepositoryMock = new Mock<IDailyRouteRepository>();
            var passengerRepositoryMock = new Mock<IPassengerRepository>();

            var startNode = Node.Create("asdas", 21, 22);
            var endNode = Node.Create("asdas", 21, 22);

            var route = Route.Create(startNode, endNode);
            var moneyValue = new MoneyValue(13, "Pln");
            
            var dailyRoute =  DailyRoute.CreateDailyRoute(DateTime.UtcNow, DateTime.UtcNow, route, Guid.NewGuid(), 5, moneyValue);
            dailyRouteRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(dailyRoute);
            
            var passenger = new Passenger(Guid.Empty, new Adress("", "", ""));
            passengerRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(passenger);
            
            var nodeManagerMock = new Mock<INodeManager>();

            var removePassengerFromRouteHandler =
                new RemovePassengerFromRouteCommandHandler(passengerRepositoryMock.Object,
                    dailyRouteRepositoryMock.Object, nodeManagerMock.Object);

            var command = new RemovePassengerFromRouteCommand() { RouteId = Guid.NewGuid(), UserId = Guid.NewGuid() };
            var result = await removePassengerFromRouteHandler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
        }
    }
}