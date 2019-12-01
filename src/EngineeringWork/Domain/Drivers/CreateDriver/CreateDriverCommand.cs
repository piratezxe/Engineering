using EngineeringWork.Web.Domain.Auth;

namespace EngineeringWork.Web.Domain.Drivers.CreateDriver
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