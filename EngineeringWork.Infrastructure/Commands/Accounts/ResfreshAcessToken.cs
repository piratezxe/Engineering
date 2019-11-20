
using MediatR;

namespace EngineeringWork.Infrastructure.Commands.Accounts
{
    public class ResfreshAcessToken : IRequest  
    {
        public string token { get; set; }
        public string Email { get; set; }
    }
}