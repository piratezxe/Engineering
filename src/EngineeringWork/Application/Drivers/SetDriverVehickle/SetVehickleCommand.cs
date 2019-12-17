using EngineeringWork.Web.Application.Auth;

namespace EngineeringWork.Web.Application.Drivers.SetDriverVehickle
{
    public class SetVehickleCommand : AuthCommandBase
    {
        public int seats { get; set; }
        
        public string brand { get; set; }
        
        public string name { get; set; }
    }
}