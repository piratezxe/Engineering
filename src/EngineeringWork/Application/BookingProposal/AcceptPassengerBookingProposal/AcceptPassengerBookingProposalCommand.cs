using System;
using EngineeringWork.Web.Domain.Auth;
using MediatR;

namespace EngineeringWork.Web.Domain.BookingProposal.AcceptPassengerBookingProposal
{
    public class AcceptPassengerBookingProposalCommand : AuthCommandBase
    {
        public Guid PassengerBookingProposalId { get; }
    }
}