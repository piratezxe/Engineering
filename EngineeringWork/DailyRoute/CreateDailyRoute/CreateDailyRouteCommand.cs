using System;
using EngineeringWork.Infrastructure.Commands.Auth;
using MediatR;

namespace EngineeringWork.Infrastructure.Commands.DailyRoute
{
    public class CreateDailyRouteCommand : AuthCommandBase
    {
        public Guid RouteId { get; set; }
        
        public double StartLatitude { get; set; }
        
        public double EndLatitude { get; set; }
        
        public double StartLongitude { get; set; }
        
        public double EndLongitude { get; set; }
        
        public DateTime StartTime { get; set; }

        public int FreeSeats { get; set; }
    }
}