using System;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Repositories;
using EngineeringWork.Infrastructure.DTO;
using EngineeringWork.Infrastructure.Services.NodeService;
using EngineeringWork.Infrastructure.Services.PassengerService;
using EngineeringWork.Infrastructure.Services.UserService;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.ServiceTest.PassengerRoute
{
    public class PassengerServiceTest
    {
        [Fact]
        public async Task when_passenger_not_exist_should_invoke_passenger_repository_async()
        {
            var passengerRepositoryMock = new Mock<IPassengerRepository>();
            var userServiceMock = new Mock<IUserService>();
            var passengerService = new PassengerSerivce(passengerRepositoryMock.Object, userServiceMock.Object);
            
            passengerRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Passenger(Guid.NewGuid(), new Adress(null, null, null)));

            userServiceMock.Setup(x => x.GetAsyncById(It.IsAny<Guid>()))
                .ReturnsAsync(new UserDto());
            
            await passengerService.CreatePassenger(Guid.NewGuid(), new Adress(null, null, null));
            
            passengerRepositoryMock.Verify(x => x.CreatePassenger(It.IsAny<Passenger>()), Times.Once);
        }
    }
}