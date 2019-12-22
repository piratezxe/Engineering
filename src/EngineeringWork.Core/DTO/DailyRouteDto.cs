using System;
using System.Collections.Generic;
using EngineeringWork.Core.Domain;

namespace EngineeringWork.Core.DTO
{
    public class DailyRouteDto
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public RouteDto Route { get;  set; }
        public IEnumerable<PassengerBookingDto> PassengerBookings { get; set; }
        public int FreeSeats { get; set; }
     
    }
}