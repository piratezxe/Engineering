using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using MediatR;

namespace EngineeringWork.Web.Application.Passenger.CreatePassenger
{
    public class CreatePassengerCommandHandler : IRequestHandler<CreatePassengerCommand>
    {
        private readonly IPassengerRepository _passengerRepository;
        public CreatePassengerCommandHandler(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }
        public async Task<Unit> Handle(CreatePassengerCommand request, CancellationToken cancellationToken)
        {
            await _passengerRepository.CreatePassenger(new Core.Domain.Passenger(request.UserId, new Adress(request.Adress.City, request.Adress.Street, request.Adress.ZipCode)));
            return Unit.Value;
        }
    }
}