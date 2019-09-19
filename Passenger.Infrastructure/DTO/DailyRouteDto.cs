using System;
using Microsoft.AspNetCore.Routing;
using Passenger.Core.Domain;
using Route = Passenger.Core.Domain.Route;

namespace Passenger.Infrastructure.DTO
{
    public class DailyRouteDto
    {
        public Guid DriverId { get; set; }
        public Guid Id { get; set; }
        public DateTime DateTime { get; protected set; }
        public Route Route { get; protected set; }
    }
}