using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Commands.Passenger;
using MediatR;

namespace EngineeringWork.Infrastructure.CommandHandlers.PassengerHandler
{
    public class CreatePassengerHandler : IRequestHandler<CreatePassengerCommand>
    {
        private readonly IPassengerRepository _passengerRepository;
        public CreatePassengerHandler(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }
        public async Task<Unit> Handle(CreatePassengerCommand request, CancellationToken cancellationToken)
        {
            await _passengerRepository.CreatePassenger(new Passenger(request.UserId, new Adress(request.Adress.City, request.Adress.Street, request.Adress.ZipCode)));
            return Unit.Value;
        }
    }
}