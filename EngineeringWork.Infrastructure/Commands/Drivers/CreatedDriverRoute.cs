using System;
using EngineeringWork.Infrastructure.Commands.Auth;

namespace EngineeringWork.Infrastructure.Commands.Drivers
{
    public class CreatedDriverRoute : AuthCommandBase
    {
        public double StartLatitude { get; set; }
        
        public double EndLatitude { get; set; }
        
        public double StartLongitude { get; set; }
        
        public double EndLongitude { get; set; }
        
        public DateTime StartTime { get; set; }

        public int FreeSeats { get; set; }
    }
}