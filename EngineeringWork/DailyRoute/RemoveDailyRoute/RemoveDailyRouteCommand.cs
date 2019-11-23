using System;
using EngineeringWork.Infrastructure.Commands.Auth;

namespace EngineeringWork.Infrastructure.Commands.Drivers
{
    public class RemoveDailyRouteCommand : AuthCommandBase
    {
        public Guid RouteId { get; set; }
    }
}