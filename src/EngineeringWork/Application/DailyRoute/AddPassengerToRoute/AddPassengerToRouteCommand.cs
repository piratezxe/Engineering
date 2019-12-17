using System;
using EngineeringWork.Web.Application.Auth;

namespace EngineeringWork.Web.Application.DailyRoute.AddPassengerToRoute
{
    public class AddPassengerToRouteCommand: AuthCommandBase
    {
        public Guid RouteId { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
    }
}