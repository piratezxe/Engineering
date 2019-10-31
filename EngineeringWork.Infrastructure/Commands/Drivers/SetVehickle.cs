using EngineeringWork.Infrastructure.Commands.Auth;

namespace EngineeringWork.Infrastructure.Commands.Drivers
{
    public class SetVehickle : AuthCommandBase
    {
        public int seats { get; set; }
        
        public string brand { get; set; }
        
        public string name { get; set; }
    }
}