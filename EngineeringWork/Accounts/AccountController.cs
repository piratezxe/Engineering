using System.Threading.Tasks;
using EngineeringWork.Core.DTO;
using EngineeringWork.Infrastructure.Commands.Accounts;
using EngineeringWork.Infrastructure.Commands.Users;
using EngineeringWork.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EngineeringWork.Web.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;

        public AccountController( 
            IMemoryCache cache, IMediator mediator) 
            : base( mediator)
        {
            _cache = cache;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Post([FromBody]LoginUserCommand command)
        {
            await Send(command);
            var jwt = _cache.GetJwt(command.Email);

            return Json(jwt);
        }   
        
        [Authorize]
        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await Send(command);

            return NoContent();
        }

        [HttpPost("/tokens/refresh")]
        public async Task<IActionResult> RefreshAcessToken([FromQuery]RefreshAcessTokenCommand command)
        {
            await Send(command);
            
            var jwt = _cache.Get<JwtDto>(command.Email);
            return Json(jwt);
        }
        [HttpPost("/tokens/revoke")]
        public async Task<IActionResult> RevokeRefreshToken([FromQuery] RevokeAcessTokenCommand command)
        {
            await Send(command);

            return NoContent();
        }
    }
}