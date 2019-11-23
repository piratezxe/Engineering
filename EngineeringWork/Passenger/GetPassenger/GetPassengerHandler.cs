using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Query.PassengerQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.QueryHandlers.PassengerHandler
{
    public class GetPassengerHandler : IRequestHandler<GetPassengerByIdQuery, Passenger>
    {

        private readonly IPassengerRepository _passengerRepository;

        public GetPassengerHandler(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<Passenger> Handle(GetPassengerByIdQuery request, CancellationToken cancellationToken)
        {
            var passenger = await _passengerRepository.GetAsync(request.PassengerId);
            if (passenger is null)
                throw new ArgumentNullException($"Passenger with {request.PassengerId} not exist");
            return passenger;
        }
    }
}
