using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Infrastructure.Application.DailyRoute.RemoveDailyRoute;
using EngineeringWork.Repository.Repositories.Interface;
using FluentAssertions;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.DailyRouteTest
{
    public class RemovePassengerFromDailyRouteCommandHandlerTest
    {
        [Fact]
        public async Task when_remove_daily_route_command_handler_should_not_be_null()
        {
            var dailyRouteRepositoryMock = new Mock<IDailyRouteRepository>();
            
            var startNode = Node.Create("asdas", 21, 22);
            var endNode = Node.Create("asdas", 21, 22);

            var route = Route.Create(startNode, endNode);
            var moneyValue = new MoneyValue(13, "Pln");
            
            var dailyRoute =  DailyRoute.CreateDailyRoute(DateTime.UtcNow, DateTime.UtcNow, route, Guid.NewGuid(), 5, moneyValue);
            
            dailyRouteRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(dailyRoute);

            var command = new RemoveDailyRouteCommand() { RouteId = Guid.NewGuid(), UserId = Guid.NewGuid()};

            var handler = new RemoveDailyRouteCommandHandler(dailyRouteRepositoryMock.Object);
            
            var result = await handler.Handle(command, CancellationToken.None);
            
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task when_remove_daily_route_and_daily_route_not_exist_should_throw_exception()
        {
            var dailyRouteRepository = new Mock<IDailyRouteRepository>();
            var command = new RemoveDailyRouteCommand() { RouteId = Guid.NewGuid(), UserId = Guid.NewGuid()};
            
            var handler = new RemoveDailyRouteCommandHandler(dailyRouteRepository.Object);
            
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            act.Should().Throw<Exception>();            
        }
    }
}