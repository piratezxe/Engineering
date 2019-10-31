using System;
using System.Collections.Generic;
using EngineeringWork.Core.Domain;

namespace EngineeringWork.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid DriverId { get;  set; }
        public Vehicle Vehicle { get; set; }
        public IEnumerable<DailyRouteDto> DailyRoutes { get; set; }
    }
}