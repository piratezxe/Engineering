using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Infrastructure.Services.NodeService;
using EngineeringWork.Web.Application.DailyRoute.CreateDailyRoute;
using FluentAssertions;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.DailyRouteTest
{
    public class AddPassengerToDailyRouteCommandHandlerTest
    {
        [Fact]
        public async Task when_create_daily_route_and_not_exist_command_handler_should_not_be_null()
        {
            var routeRepositoryMock = new Mock<IDailyRouteRepository>();
            var nodeManagerMock = new Mock<INodeManager>();
            var driverRepositoryMock = new Mock<IDriverRepository>();

            var startNode = Node.Create("asdas", 21, 22);
            var endNode = Node.Create("asdas", 21, 22);

            var route = Route.Create(startNode, endNode);
            var moneyValue = new MoneyValue(13, "Pln");

            var dailyRoute =
                DailyRoute.CreateDailyRoute(DateTime.UtcNow, DateTime.UtcNow, route, Guid.NewGuid(), 5, moneyValue);

            routeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(dailyRoute);

            var command = new CreateDailyRouteCommand()
            {
                RouteId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                EndLatitude = 21,
                StartLatitude = 21,
                StartDateTime = DateTime.Now,
                EndLongitude = 21,
                StartLongitude = 21
            };

            var handler = new CreateDailyRouteCommandHandler(driverRepositoryMock.Object, nodeManagerMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task when_add_passenger_to_route_and_route_not_exist_should_throw_exception_async()
        {
            var driverRepositoryMock = new Mock<IDriverRepository>();
            var nodeManagerMock = new Mock<INodeManager>();

            var command = new CreateDailyRouteCommand()
            {
                RouteId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                EndLatitude = 21,
                StartLatitude = 21,
                StartDateTime = DateTime.Now,
                EndLongitude = 21,
                StartLongitude = 21
            };

            var handler = new CreateDailyRouteCommandHandler(driverRepositoryMock.Object, nodeManagerMock.Object);

            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            act.Should().Throw<Exception>();
        }
        
        [Fact]
        public async Task when_try_to_create_passenger_and_command_are_null_should_not_find_command_handler_and_throw_exception()
        {
            
            var driverRepositoryMock = new Mock<IDriverRepository>();
            var nodeManagerMock = new Mock<INodeManager>();
            var dailyRouteRepositoryMock = new Mock<IDailyRouteRepository>();
            
            var startNode = Node.Create("asdas", 21, 22);
            var endNode = Node.Create("asdas", 21, 22);

            var route = Route.Create(startNode, endNode);
            var moneyValue = new MoneyValue(13, "Pln");

            var dailyRoute =
                DailyRoute.CreateDailyRoute(DateTime.UtcNow, DateTime.UtcNow, route, Guid.NewGuid(), 5, moneyValue);

            dailyRouteRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(dailyRoute);
            
            CreateDailyRouteCommand command = null;
 
            var handler = new CreateDailyRouteCommandHandler(driverRepositoryMock.Object, nodeManagerMock.Object);

            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);
            act.Should().Throw<Exception>();
        }
    }
}