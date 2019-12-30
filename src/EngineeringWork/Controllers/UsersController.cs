using System.Net;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Application.Users.CreateUser;
using EngineeringWork.Infrastructure.Application.Users.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Controllers
{
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await Send(new GetAllUserQuery());
            if(user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody]CreateUserCommand command)
        {
            await Send(command);
            return Created($"users/{command.Email}", new object());
        }
    }
}
