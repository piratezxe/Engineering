
using MediatR;

namespace EngineeringWork.Web.Domain.Accounts.RefreshAcessToken
{
    public class RefreshAcessTokenCommand : IRequest  
    {
        public string token { get; set; }
        public string Email { get; set; }
    }
}