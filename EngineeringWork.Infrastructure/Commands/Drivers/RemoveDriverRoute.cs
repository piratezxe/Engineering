using System;
using EngineeringWork.Infrastructure.Commands.Auth;

namespace EngineeringWork.Infrastructure.Commands.Drivers
{
    public class RemoveDriverRoute : AuthCommandBase
    {
        public Guid RouteId { get; set; }
    }
}