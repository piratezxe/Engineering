using System;
using System.Collections.Generic;
using EngineeringWork.Core.Domain;

namespace EngineeringWork.Infrastructure.DTO
{
    public class DailyRouteDto
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public RouteDto Route { get;  set; }
        public IEnumerable<PassengerNode> PassengerNodes { get; set; }

    }
}