using System;
using Passenger.Infrastructure.Commands.Auth;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class RemoveDriverRoute : AuthCommandBase
    {
        public Guid RouteId { get; set; }
    }
}