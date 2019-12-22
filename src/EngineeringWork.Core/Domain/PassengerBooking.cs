using System;

namespace EngineeringWork.Core.Domain
{
    public class PassengerBooking
    {
        public PassengerBooking(Guid passengerBookingProposal, Guid id, string driverPhoneNumber, bool isActive, string passengerName, string fromPlace, string toPlace, DateTime startTime)
        {
            Id = id;
            DriverPhoneNumber = driverPhoneNumber;
            IsActive = isActive;
            PassengerName = passengerName;
            FromPlace = fromPlace;
            ToPlace = toPlace;
            StartTime = startTime;
            PassengerBookingProposalId = passengerBookingProposal;
        }

        private PassengerBooking()
        {
            
        }
        
        public DateTime StartTime { get; private set; }
        public string DriverPhoneNumber { get; private set; }
        public Guid PassengerBookingProposalId { get; private set; }
        public String PassengerName { get; private set; }
        
        public string FromPlace { get; private set; }
        
        public string ToPlace { get; private set; }
        
        public bool IsActive { get; private set; }
        
        public Guid Id { get; private set; }
    }
}