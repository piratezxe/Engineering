using System;
using Passenger.Infrastructure.Commands.Auth;

namespace Passenger.Infrastructure.Commands.Passenger
{
    public class RemovePassengerFromRoute : AuthCommandBase
    {
        public Guid RouteId { get; set; }
    }
}