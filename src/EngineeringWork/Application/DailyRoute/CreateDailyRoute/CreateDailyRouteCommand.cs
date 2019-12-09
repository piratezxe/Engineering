using System;
using EngineeringWork.Core.Domain;
using EngineeringWork.Web.Domain.Auth;

namespace EngineeringWork.Web.Domain.DailyRoute.CreateDailyRoute
{
    public class CreateDailyRouteCommand : AuthCommandBase
    {
        public double StartLatitude { get; set; }
        
        public double EndLatitude { get; set; }
        
        public double StartLongitude { get; set; }
        
        public double EndLongitude { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public DateTime BeginingTime { get; set; }

        public int FreeSeats { get; set; }

        public MoneyValue moneyValue { get; set;}

        public Guid RouteId { get; set; }
    }
}