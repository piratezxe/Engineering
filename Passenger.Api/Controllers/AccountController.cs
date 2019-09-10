using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Accounts;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Extensions;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;

        public AccountController(ICommandDispatcher commandDispatcher,
            IMemoryCache cache) 
            : base(commandDispatcher)
        {
            _cache = cache;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            await CommandDispatcher.DispatchAsync(command);
            var jwt = _cache.GetJwt(command.Email);

            return Json(jwt);
        }   
        
        [Authorize]
        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }

        [Authorize]
        [HttpPost("/tokens/{token}/refresh")]
        public async Task<IActionResult> RefreshAcessToken(ResfreshAcessToken command)
        {
            await CommandDispatcher.DispatchAsync(command);
            
            var jwt = _cache.Get<JwtDto>(command.Email);
            return Json(jwt);
        }
        [Authorize]
        [HttpPost("/tokens/{token}/revoke")]
        public async Task<IActionResult> RevokeRefreshToken(RevokeAcessToken command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}