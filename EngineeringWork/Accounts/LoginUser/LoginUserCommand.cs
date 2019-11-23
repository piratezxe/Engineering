using MediatR;

namespace EngineeringWork.Infrastructure.Commands.Accounts
{
    public class LoginUserCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}