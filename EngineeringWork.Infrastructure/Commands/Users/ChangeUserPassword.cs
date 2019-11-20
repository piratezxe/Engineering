using EngineeringWork.Infrastructure.Commands.Auth;
using MediatR;

namespace EngineeringWork.Infrastructure.Commands.Users
{
    public class ChangeUserPassword : AuthCommandBase
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}