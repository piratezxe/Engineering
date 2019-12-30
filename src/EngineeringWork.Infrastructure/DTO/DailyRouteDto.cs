using System;
using System.Collections.Generic;

namespace EngineeringWork.Infrastructure.DTO
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