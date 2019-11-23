using EngineeringWork.Infrastructure.Commands.Auth;

namespace EngineeringWork.Infrastructure.Commands.Drivers
{
    public class CreateDriverCommand : AuthCommandBase
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