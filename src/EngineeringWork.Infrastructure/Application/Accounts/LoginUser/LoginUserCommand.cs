using MediatR;

namespace EngineeringWork.Infrastructure.Application.Accounts.LoginUser
{
    public class LoginUserCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}