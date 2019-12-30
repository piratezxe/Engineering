using System;

namespace EngineeringWork.Core.Domain
{
    public class PassengerBookingProposalDecision
    {
        public ProposalStatus ProposalStatus { get; private set; }
        public DateTime DateTime { get; set; }
        public string RejectReason { get; set; }

        private PassengerBookingProposalDecision(ProposalStatus proposalStatus, string rejectReason, DateTime dateTime)
        {
            ProposalStatus = proposalStatus;
            RejectReason = rejectReason;
            DateTime = dateTime;
        }

        public PassengerBookingProposalDecision()
        {
        }     
        
        public static PassengerBookingProposalDecision RejectDecision(string rejectReason, DateTime dateTime)
        {
            return new PassengerBookingProposalDecision(ProposalStatus.Rejected,  rejectReason, dateTime);
        }
        
        public static PassengerBookingProposalDecision AcceptDecision(DateTime dateTime)
        {
            return new PassengerBookingProposalDecision(ProposalStatus.Accepted, null, dateTime);
        }

        public static PassengerBookingProposalDecision CreateToVerification(DateTime dateTime)
        {
            return new PassengerBookingProposalDecision(ProposalStatus.ToVerify, null, dateTime );
        }
    }
}