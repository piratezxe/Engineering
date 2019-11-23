using System;
using EngineeringWork.Infrastructure.Commands.Auth;

namespace EngineeringWork.Infrastructure.Commands.Passenger
{
    public class RemovePassengerFromRouteCommand : AuthCommandBase
    {
        public Guid RouteId { get; set; }
    }
}