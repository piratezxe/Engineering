using System;

namespace EngineeringWork.Core.Domain
{
    public class PassengerBookingProposal
    {
        public Guid Id { get; private set; }
        public Guid UserPropsalId { get; private set; }
        public DateTime CreateTime { get; private set; }  
        public PassengerBookingProposalDecision PassengerBookingProposalDecision { get; private set; }
        
        private PassengerBookingProposal(DateTime createTime, Guid id, Guid userPropsalId)
        {
            CreateTime = createTime;
            Id = id;
            UserPropsalId = userPropsalId;
        }

        //defined for entity framework
        private PassengerBookingProposal()
        {
        }

        public static PassengerBookingProposal CreateToVerify(Guid id, DateTime createTime, Guid userPropsalId)
            => new PassengerBookingProposal(createTime, id, userPropsalId);

        public void Accept(Guid userId)
        {
            //check rule
            PassengerBookingProposalDecision = PassengerBookingProposalDecision.AcceptDecision(userId, DateTime.UtcNow);
        }

        public void Rejected(Guid userId, string rejectedReason)
        {
            //check rule
            PassengerBookingProposalDecision = PassengerBookingProposalDecision.RejectDecision(userId, rejectedReason, DateTime.UtcNow);
        }
    }
}