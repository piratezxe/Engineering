using System;
using System.Collections.Generic;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid DriverId { get;  set; }
        public Vehicle Vehicle { get; set; }
        public IEnumerable<DailyRouteDto> DailyRoutes { get; set; }
    }
}