using System;
using EngineeringWork.Core.Domain;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.DTO
{
    public class RouteDto
    {
        public Guid RouteId { get; set; }
        public Node StartNode { get; protected set; }
        public Node EndNode { get; protected set; }
    }
}