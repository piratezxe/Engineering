using System;
using EngineeringWork.Core.Domain;

namespace EngineeringWork.Infrastructure.DTO
{
    public class PassengerBookingDto
    {
        public Guid Id { get; set; }
        public Passenger Passenger { get;  set; }
    }
}
