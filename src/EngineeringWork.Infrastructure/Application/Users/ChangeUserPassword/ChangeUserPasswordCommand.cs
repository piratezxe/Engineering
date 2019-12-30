using EngineeringWork.Infrastructure.Application.Auth;

namespace EngineeringWork.Infrastructure.Application.Users.ChangeUserPassword
{
    public class ChangeUserPasswordCommand : AuthCommandBase
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}