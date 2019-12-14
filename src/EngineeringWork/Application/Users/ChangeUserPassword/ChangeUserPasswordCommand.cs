using EngineeringWork.Web.Application.Auth;

namespace EngineeringWork.Web.Application.Users.ChangeUserPassword
{
    public class ChangeUserPasswordCommand : AuthCommandBase
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}