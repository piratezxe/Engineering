using System;
using Passenger.Infrastructure.Commands.Auth;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class AddDriverRoute : AuthCommandBase
    {
        public double StartLatitude { get; set; }
        
        public double EndLatitude { get; set; }
        
        public double StartLongitude { get; set; }
        
        public double EndLongitude { get; set; }
        
        public DateTime StartTime { get; set; }
    }
}