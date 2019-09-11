using System;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class AddDriverRoute : ICommand
    {
        public double StartLatitude { get; set; }
        
        public double EndLatitude { get; set; }
        
        public double StartLongitude { get; set; }
        
        public double EndLongitude { get; set; }
        
        public string Name { get; set; }
        
    }
}