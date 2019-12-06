using System;
using EngineeringWork.Web.Domain.Auth;

namespace EngineeringWork.Web.Domain.BookingProposal.RequestPassengerBookingProposalVerification
{
    public class RequestPassengerBookingProposalVerificationCommand : AuthCommandBase
    {
        public Guid ProposalId { get; set; }
        
        public Guid ProposalUserId { get; set; }
        
        public DateTime ProposalDate { get; set; }
    }
}