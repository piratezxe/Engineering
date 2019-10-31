using System;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Infrastructure.Commands;
using EngineeringWork.Infrastructure.Commands.PassengerCommands;
using EngineeringWork.Infrastructure.Services.PassengerService;

namespace EngineeringWork.Infrastructure.Handlers.Passenger
{
    public class CreatePassengerHandler : ICommandHandler<CreatePassenger>
    {
        private readonly IPassengerService _passengerService;

        public CreatePassengerHandler(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        public async Task HandleAsync(CreatePassenger command)
        {
            await _passengerService.CreatePassenger(command.UserId, new Adress(command.Adress.City, command.Adress.Street, command.Adress.ZipCode));
        }
    }
}