using Passenger.Infrastructure.Commands.Auth;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class SetVehickle : AuthCommandBase
    {
        public int seats { get; set; }
        
        public string brand { get; set; }
        
        public string name { get; set; }
    }
}