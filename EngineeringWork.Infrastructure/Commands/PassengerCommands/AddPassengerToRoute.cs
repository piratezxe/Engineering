using System;
using EngineeringWork.Infrastructure.Commands.Auth;

namespace EngineeringWork.Infrastructure.Commands.PassengerCommands
{
    public class AddPassengerToRoute : AuthCommandBase
    {
        public Guid RouteId { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
    }
}