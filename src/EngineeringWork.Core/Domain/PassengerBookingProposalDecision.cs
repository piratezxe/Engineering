using System;
using System.ComponentModel.DataAnnotations;

namespace EngineeringWork.Core.Domain
{
    public class PassengerBookingProposalDecision
    {
        [Key]
        public Guid Id { get; private set; }
        public Guid UserId { get;  }
        public PropsalStatus PropsalStatus { get; }
        public DateTime DateTime { get; }
        public string RejectReason { get; }

        private PassengerBookingProposalDecision(Guid userId, PropsalStatus status, string rejectReason, DateTime dateTime)
        {
            UserId = userId;
            PropsalStatus = PropsalStatus;
            RejectReason = rejectReason;
            DateTime = dateTime;
        }

        public PassengerBookingProposalDecision()
        {
        }     
        
        public static PassengerBookingProposalDecision RejectDecision(Guid userId, string rejectReason, DateTime dateTime)
        {
            return new PassengerBookingProposalDecision(userId, PropsalStatus.Acepted,  rejectReason, dateTime);
        }

        public static PassengerBookingProposalDecision AcceptDecision(Guid userId, DateTime dateTime)
        {
            return new PassengerBookingProposalDecision(userId, PropsalStatus.Rejcted, null, dateTime);
        }
    }

    public enum PropsalStatus
    {
        Acepted, 
        Rejcted,
        ToVerify
    }
}