using EngineeringWork.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringWork.Core.DTO
{
    public class PassengerBookingDto
    {
        public Guid Id { get; set; }
        public Passenger Passenger { get;  set; }
    }
}
