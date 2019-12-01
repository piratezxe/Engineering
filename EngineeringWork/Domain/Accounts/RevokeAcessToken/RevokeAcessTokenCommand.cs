using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Domain.Accounts.RevokeAcessToken
{
    public class RevokeAcessTokenCommand : IRequest  
    {
        [FromQuery(Name = "token")]
        public string Token { get; set; }
    }
}