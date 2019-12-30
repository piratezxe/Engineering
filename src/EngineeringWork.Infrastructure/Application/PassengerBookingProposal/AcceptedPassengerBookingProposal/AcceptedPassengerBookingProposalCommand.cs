using System;
using EngineeringWork.Infrastructure.Application.Auth;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.PassengerBookingProposal.AcceptedPassengerBookingProposal
{
    public class AcceptedPassengerBookingProposalCommand : AuthCommandBase, IRequest
    {
        public Guid ProposalId { get; set; }
    }
}