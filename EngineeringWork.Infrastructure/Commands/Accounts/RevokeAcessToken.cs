
using Microsoft.AspNetCore.Mvc;

namespace Passenger.Infrastructure.Commands.Accounts
{
    public class RevokeAcessToken : ICommand
    {
        [FromQuery(Name = "token")]
        public string Token { get; set; }
    }
}