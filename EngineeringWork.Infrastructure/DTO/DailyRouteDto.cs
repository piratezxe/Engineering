using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Passenger.Core.Domain;
using Route = Passenger.Core.Domain.Route;

namespace Passenger.Infrastructure.DTO
{
    public class DailyRouteDto
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public RouteDto Route { get;  set; }
        public IEnumerable<PassengerNode> PassengerNodes { get; set; }

    }
}