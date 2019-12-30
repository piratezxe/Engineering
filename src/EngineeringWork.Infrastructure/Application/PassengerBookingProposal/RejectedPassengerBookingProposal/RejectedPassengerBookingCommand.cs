using System;
using EngineeringWork.Infrastructure.Application.Auth;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.PassengerBookingProposal.RejectedPassengerBookingProposal
{
    public class RejectedPassengerBookingCommand : AuthCommandBase, IRequest
    {
        public Guid ProposalId { get; }

        public string RejectedReason { get; }

        public RejectedPassengerBookingCommand(Guid proposalId, string rejectedReason)
        {
            ProposalId = proposalId;
            RejectedReason = rejectedReason;
        }
    }
}
