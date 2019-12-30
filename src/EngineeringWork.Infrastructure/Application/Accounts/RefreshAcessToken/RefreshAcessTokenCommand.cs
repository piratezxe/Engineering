
using MediatR;

namespace EngineeringWork.Infrastructure.Application.Accounts.RefreshAcessToken
{
    public class RefreshAcessTokenCommand : IRequest  
    {
        public string token { get; set; }
        public string Email { get; set; }
    }
}