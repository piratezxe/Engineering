using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Repository.Repositories.Interface;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.Passenger.GetPassenger
{
    public class GetPassengerHandler : IRequestHandler<GetPassengerByIdQuery, Core.Domain.Passenger>
    {

        private readonly IPassengerRepository _passengerRepository;

        public GetPassengerHandler(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<Core.Domain.Passenger> Handle(GetPassengerByIdQuery request, CancellationToken cancellationToken)
        {
            var passenger = await _passengerRepository.GetAsync(request.PassengerId);
            if (passenger is null)
                throw new ArgumentNullException($"Passenger with {request.PassengerId} not exist");
            return passenger;
        }
    }
}
