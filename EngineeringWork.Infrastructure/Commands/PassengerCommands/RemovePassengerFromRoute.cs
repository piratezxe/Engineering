using System;
using EngineeringWork.Infrastructure.Commands.Auth;

namespace EngineeringWork.Infrastructure.Commands.PassengerCommands
{
    public class RemovePassengerFromRoute : AuthCommandBase
    {
        public Guid RouteId { get; set; }
    }
}