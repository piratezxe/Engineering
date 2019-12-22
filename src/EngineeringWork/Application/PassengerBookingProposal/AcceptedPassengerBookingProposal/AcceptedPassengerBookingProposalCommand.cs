using System;
using EngineeringWork.Web.Application.Auth;
using MediatR;

namespace EngineeringWork.Web.Application.PassengerBookingProposal.AcceptedPassengerBookingProposal
{
    public class AcceptedPassengerBookingProposalCommand : AuthCommandBase, IRequest
    {
        public Guid ProposalId { get; set; }
    }
}