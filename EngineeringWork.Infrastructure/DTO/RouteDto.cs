using System;
using EngineeringWork.Core.Domain;

namespace EngineeringWork.Infrastructure.DTO
{
    public class RouteDto
    {
        public Guid RouteId { get; set; }
        public Node StartNode { get; protected set; }
        public Node EndNode { get; protected set; }
    }
}