using System;
using EngineeringWork.Infrastructure.Commands.Auth;

namespace EngineeringWork.Infrastructure.Commands.Passenger
{
    public class AddPassengerToRouteCommand: AuthCommandBase
    {
        public Guid RouteId { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
    }
}