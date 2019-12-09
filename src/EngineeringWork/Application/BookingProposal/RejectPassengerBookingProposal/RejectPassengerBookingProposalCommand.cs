using System;
using EngineeringWork.Web.Domain.Auth;

namespace EngineeringWork.Web.Domain.BookingProposal.RejectPassengerBookingProposal
{
    public class RejectPassengerBookingProposalCommand : AuthCommandBase
    {
        public Guid PassengerBookingPropsalId { get; set; } 
        
        public string RejectedReason { get; set; }
    }
}