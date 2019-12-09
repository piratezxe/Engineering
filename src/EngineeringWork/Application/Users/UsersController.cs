using System.Net;
using System.Threading.Tasks;
using EngineeringWork.Web.Application;
using EngineeringWork.Web.Domain.Users.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Domain.Users
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
        public async Task<IActionResult> Post([FromBody]CreateUser.CreateUserCommand command)
        {
            await Send(command);
            return Created($"users/{command.Email}", new object());
        }
    }
}
