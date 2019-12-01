using System;
using EngineeringWork.Web.Domain.Auth;

namespace EngineeringWork.Web.Domain.DailyRoute.AddPassengerToRoute
{
    public class AddPassengerToRouteCommand: AuthCommandBase
    {
        public Guid RouteId { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
    }
}