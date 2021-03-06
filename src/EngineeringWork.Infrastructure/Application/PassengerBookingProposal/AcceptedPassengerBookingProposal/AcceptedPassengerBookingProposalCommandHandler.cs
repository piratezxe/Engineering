using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Extensions;
using EngineeringWork.Repository.Repositories.Interface;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.PassengerBookingProposal.AcceptedPassengerBookingProposal
{
    public class AcceptedPassengerBookingProposalCommandHandler : IRequestHandler<AcceptedPassengerBookingProposalCommand>
    {
        private readonly IPassengerBookingProposalRepository _passengerBookingProposalRepository;

        private readonly IDailyRouteRepository _dailyRouteRepository;

        public AcceptedPassengerBookingProposalCommandHandler(
            IPassengerBookingProposalRepository passengerBookingProposalRepository, 
            IDailyRouteRepository dailyRouteRepository)
        {
            _passengerBookingProposalRepository = passengerBookingProposalRepository;
            _dailyRouteRepository = dailyRouteRepository;
        }
        public async Task<Unit> Handle(AcceptedPassengerBookingProposalCommand request, CancellationToken cancellationToken)
        {
            var proposal = await _passengerBookingProposalRepository.GetOrFailAsync(request.ProposalId);
            var dailyRoute = await _dailyRouteRepository.GetOrFailAsync(proposal.DailyRouteId);

            dailyRoute.AcceptedPassengerBookingProposal(request.ProposalId);
            await _dailyRouteRepository.UpdateAsync(dailyRoute);
            
            return Unit.Value;
        }
    }
}