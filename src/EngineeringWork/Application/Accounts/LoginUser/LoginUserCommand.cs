using MediatR;

namespace EngineeringWork.Web.Application.Accounts.LoginUser
{
    public class LoginUserCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}