using EngineeringWork.Infrastructure.Commands.Auth;

namespace EngineeringWork.Infrastructure.Commands.Drivers
{
    public class SetVehickleCommand : AuthCommandBase
    {
        public int seats { get; set; }
        
        public string brand { get; set; }
        
        public string name { get; set; }
    }
}