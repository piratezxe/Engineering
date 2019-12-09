using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Interface.Repositories;
using MediatR;

namespace EngineeringWork.Web.Domain.BookingProposal.RejectPassengerBookingProposal
{
    public class RejectPassengerBookingPropsalCommandHandler : IRequestHandler<RejectPassengerBookingProposalCommand>
    {
        private readonly IPassengerBookingProposalRepository _passengerBookingProposalRepository;

        public RejectPassengerBookingPropsalCommandHandler(IPassengerBookingProposalRepository passengerBookingProposalRepository)
        {
            _passengerBookingProposalRepository = passengerBookingProposalRepository;
        }

        public async Task<Unit> Handle(RejectPassengerBookingProposalCommand request, CancellationToken cancellationToken)
        {
            var proposal = await _passengerBookingProposalRepository.GetByIdAsync(request.PassengerBookingPropsalId);
            if(proposal is null)
                throw new ArgumentNullException($"Proposal with {request.PassengerBookingPropsalId} not exist");
            
            proposal.Rejected(request.UserId, request.RejectedReason);
            return Unit.Value;
        }
    }
}