using EngineeringWork.Web.Domain.Auth;

namespace EngineeringWork.Web.Domain.Users.ChangeUserPassword
{
    public class ChangeUserPasswordCommand : AuthCommandBase
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}