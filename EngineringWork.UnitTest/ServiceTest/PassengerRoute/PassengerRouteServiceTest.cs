using System;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Repositories;
using EngineeringWork.Infrastructure.Services.NodeService;
using EngineeringWork.Infrastructure.Services.PassengerRouteService;
using EngineeringWork.Infrastructure.Services.PassengerService;
using FluentAssertions;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.ServiceTest.PassengerRoute
{
    public class PassengerRouteServiceTest
    {
        private readonly Passenger passenger;
        
        public PassengerRouteServiceTest()
        {
            passenger = new Passenger(Guid.NewGuid(), new Adress(null,null,null));
        }
        [Fact]
        public async Task when_add_passenger_to_route_and_passenger_not_exist_should_throw_exception_async()
        {
            //arrange
            var passengerServiceMock = new Mock<IPassengerService>();
            var routeRepositoryMock = new Mock<IRouteRepository>();
            var nodeManagerMock = new Mock<INodeManager>();
            var mapperMock = new Mock<IMapper>();
            
            var passengerService = new PassengerRouteService(passengerServiceMock.Object, routeRepositoryMock.Object, nodeManagerMock.Object, mapperMock.Object);
            
            passengerServiceMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync( () =>  null);

            //act
            Func<Task> f = async () =>
            {
                await passengerService.AddPassengerToRoute(Guid.NewGuid(), Guid.NewGuid(), 12, 12);
            };
            await f.Should().ThrowAsync<ArgumentException>();
        }
        
        [Fact]
        public async Task when_add_passenger_to_route_and_route_not_exist_should_throw_exception_async()
        {
            var passengerServiceMock = new Mock<IPassengerService>();
            var routeRepositoryMock = new Mock<IRouteRepository>();
            var nodeManagerMock = new Mock<INodeManager>();
            var mapperMock = new Mock<IMapper>();
            
            var passengerService = new PassengerRouteService(passengerServiceMock.Object, routeRepositoryMock.Object, nodeManagerMock.Object, mapperMock.Object);
            
            passengerServiceMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync( () =>  passenger);
            routeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(() => null);
            
            //act
            Func<Task> f = async () =>
            {
                await passengerService.AddPassengerToRoute(Guid.NewGuid(), Guid.NewGuid(), 12, 12);
            };
            await f.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task when_add_passenger_to_route_shoulde_invoke_add_passenger_to_repository_async_once()
        {
            var passengerServiceMock = new Mock<IPassengerService>();
            var routeRepositoryMock = new Mock<IRouteRepository>();
            var nodeManagerMock = new Mock<INodeManager>();
            var mapperMock = new Mock<IMapper>();
            var passengerService = new PassengerRouteService(passengerServiceMock.Object, routeRepositoryMock.Object, nodeManagerMock.Object, mapperMock.Object);

            passengerServiceMock.Setup(x => x.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(() => passenger);
            routeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(() => new DailyRoute());

            await passengerService.AddPassengerToRoute(Guid.NewGuid(), Guid.NewGuid(), 12, 13);
            routeRepositoryMock.Verify( x => x.UpdateAsync(It.IsAny<DailyRoute>()), Times.Once);
        }

        [Fact]
        public async Task when_remove_passenger_from_route_should_invoke_remove_passenger_from_route_async_once()
        {
            var passengerServiceMock = new Mock<IPassengerService>();
            var routeRepositoryMock = new Mock<IRouteRepository>();
            var nodeManagerMock = new Mock<INodeManager>();
            var mapperMock = new Mock<IMapper>();
            
            var passengerService = new PassengerRouteService(passengerServiceMock.Object, routeRepositoryMock.Object, nodeManagerMock.Object, mapperMock.Object);

            passengerServiceMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(passenger);
            routeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(new DailyRoute());
            
            await passengerService.RemovePassengerFromRoute(Guid.NewGuid(), Guid.NewGuid());
            routeRepositoryMock.Verify( x => x.UpdateAsync(It.IsAny<DailyRoute>()), Times.Once);
        }
    }
}