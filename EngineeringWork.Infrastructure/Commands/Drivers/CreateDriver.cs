using Passenger.Infrastructure.Commands.Auth;

namespace EngineeringWork.Infrastructure.Commands.Drivers
{
    public class CreateDriver : AuthCommandBase
    {
        public DriverVehicle Vehicle { get; set; }
        public class DriverVehicle 
        {
            public string Brand { get; set; }
            public string Name { get; set; }
            public int Seats { get;  set; }
        }
    }
}