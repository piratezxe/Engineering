using System;
using EngineeringWork.Web.Application.Auth;
using MediatR;

namespace EngineeringWork.Web.Application.PassengerBookingProposal.RejectedPassengerBookingProposal
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
