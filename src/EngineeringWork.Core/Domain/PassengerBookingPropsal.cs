using System;

namespace EngineeringWork.Core.Domain
{
    public class PassengerBookingProposal
    {
        public Guid Id { get; private set; }
        public Guid UserProposalId { get; private set; }
        public Guid DailyRouteId { get; private set; }
        public DateTime CreateTime { get; private set; }
        public int SeatsQuantity { get; private set; }
        public PassengerBookingProposalDecision PassengerBookingProposalDecision { get; private set; }

        private PassengerBookingProposal(DateTime createTime, Guid id, Guid userProposalId, Guid dailyRouteId,
            int seatsQuantity)
        {
            CreateTime = createTime;
            Id = id;
            UserProposalId = userProposalId;
            DailyRouteId = dailyRouteId;
            SeatsQuantity = seatsQuantity;
        }

        //defined for entity framework
        private PassengerBookingProposal()
        {
        }

        public static PassengerBookingProposal CreateToVerify(Guid id, DateTime createTime, Guid userProposalId,
            Guid dailyRouteId, int seatsQuantity)
        {
            return new PassengerBookingProposal(createTime, id, userProposalId, dailyRouteId, seatsQuantity);
        }

        public void Verify()
        {
            PassengerBookingProposalDecision = PassengerBookingProposalDecision.CreateToVerification(DateTime.UtcNow);
        }

        public void Accept()
        {
            //check rule
            PassengerBookingProposalDecision = PassengerBookingProposalDecision.AcceptDecision(DateTime.UtcNow);
        }

        public void Rejected(string rejectedReason)
        {
            //check rule
            PassengerBookingProposalDecision = PassengerBookingProposalDecision.RejectDecision(rejectedReason, DateTime.UtcNow);
        }
    }
}