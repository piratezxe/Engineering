using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Extensions.RepositoryExtensions;
using MediatR;

namespace EngineeringWork.Web.Application.PassengerBookingProposal.CreatePassengerBookingProposal
{
    public class CreatePassengerBookingProposalCommandHandler : IRequestHandler<CreatePassengerBookingProposalCommand>
    {
        private readonly IPassengerBookingProposalRepository _passengerBookingProposalRepository;

        private readonly IDailyRouteRepository _dailyRouteRepository;

        public CreatePassengerBookingProposalCommandHandler(IPassengerBookingProposalRepository passengerBookingProposalRepository, IDailyRouteRepository dailyRouteRepository)
        {
            _passengerBookingProposalRepository = passengerBookingProposalRepository;
            _dailyRouteRepository = dailyRouteRepository;
        }
        public async Task<Unit> Handle(CreatePassengerBookingProposalCommand request, CancellationToken cancellationToken)
        {
            var dailyRoute = await _dailyRouteRepository.GetOrFailAsync(request.DailyRouteId);
            dailyRoute.AddPassengerBookingProposal(DateTime.Now, Guid.NewGuid(), request.UserId, request.SeatsQuantity);
            await _dailyRouteRepository.UpdateAsync(dailyRoute);

            return Unit.Value;
        }
    }
}