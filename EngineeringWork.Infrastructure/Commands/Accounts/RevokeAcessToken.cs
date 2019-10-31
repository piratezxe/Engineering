
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Infrastructure.Commands.Accounts
{
    public class RevokeAcessToken : ICommand
    {
        [FromQuery(Name = "token")]
        public string Token { get; set; }
    }
}