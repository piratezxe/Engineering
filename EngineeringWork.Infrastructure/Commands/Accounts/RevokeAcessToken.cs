
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Infrastructure.Commands.Accounts
{
    public class RevokeAcessToken : IRequest  
    {
        [FromQuery(Name = "token")]
        public string Token { get; set; }
    }
}