using System;
using Passenger.Infrastructure.Commands.Auth;

namespace Passenger.Infrastructure.Commands.Passenger
{
    public class AddPassengerToRoute : AuthCommandBase
    {
        public Guid RouteId { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
    }
}