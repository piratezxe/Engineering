using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Extensions.RepositoryExtensions;
using MediatR;

namespace EngineeringWork.Web.Application.PassengerBookingProposal.RejectedPassengerBookingProposal
{
    public class RejectedPassengerBookingCommandHandler : IRequestHandler<RejectedPassengerBookingCommand>
    {
        private readonly IPassengerBookingProposalRepository _passengerBookingProposalRepository;

        private readonly IDailyRouteRepository _dailyRouteRepository;

        public RejectedPassengerBookingCommandHandler(IPassengerBookingProposalRepository passengerBookingProposalRepository, IDailyRouteRepository dailyRouteRepository)
        {
            _passengerBookingProposalRepository = passengerBookingProposalRepository;
            _dailyRouteRepository = dailyRouteRepository;
        }
        public async Task<Unit> Handle(RejectedPassengerBookingCommand request, CancellationToken cancellationToken)
        {
            var proposal = await _passengerBookingProposalRepository.GetOrFailAsync(request.ProposalId);
            var dailyRoute = await _dailyRouteRepository.GetOrFailAsync(proposal.DailyRouteId);
            
            dailyRoute.RejectedPassengerBookingProposal(request.RejectedReason, request.ProposalId);
            await _dailyRouteRepository.UpdateAsync(dailyRoute);
            
            return  Unit.Value;;
        }
    }
}
