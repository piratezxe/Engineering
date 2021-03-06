using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Infrastructure.Application.Passenger.CreatePassenger;
using EngineeringWork.Repository.Repositories.Interface;
using FluentAssertions;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.PassengerTest
{
    public class CreatePassengerCommandHandlerTest
    {
        [Fact]
        public async Task create_passenger_handler_should_not_be_null()
        {
            var routeRepositoryMock = new Mock<IPassengerRepository>();
            var passengerHandler = new CreatePassengerCommandHandler(routeRepositoryMock.Object);
            
            routeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync( new Passenger(Guid.NewGuid(), new Address("", "", "")));
            
            var result = await passengerHandler.Handle(new CreatePassengerCommand() { UserId = Guid.NewGuid(), Adress = new CreatePassengerCommand.PassengerAdres()}, CancellationToken.None);
            result.Should().NotBeNull();
        }
    }
}