using EngineeringWork.Web.Domain.Auth;

namespace EngineeringWork.Web.Domain.Drivers.SetDriverVehickle
{
    public class SetVehickleCommand : AuthCommandBase
    {
        public int seats { get; set; }
        
        public string brand { get; set; }
        
        public string name { get; set; }
    }
}