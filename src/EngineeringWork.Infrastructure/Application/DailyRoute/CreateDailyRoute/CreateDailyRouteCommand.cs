using System;
using EngineeringWork.Core.Domain;
using EngineeringWork.Infrastructure.Application.Auth;

namespace EngineeringWork.Infrastructure.Application.DailyRoute.CreateDailyRoute
{
    public class CreateDailyRouteCommand : AuthCommandBase
    {
        public double StartLatitude { get; set; }
        
        public double EndLatitude { get; set; }
        
        public double StartLongitude { get; set; }
        
        public double EndLongitude { get; set; }
        
        public DateTime StartDateTime { get; set; }
        
        public DateTime CreateDateTime { get; set; }

        public int FreeSeats { get; set; }

        public MoneyValue MoneyValue { get; set;}

        public Guid RouteId { get; set; }
    }
}