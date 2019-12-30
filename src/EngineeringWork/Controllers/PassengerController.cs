using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Application.Passenger.CreatePassenger;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Controllers
{
    [Authorize]
    public class PassengerController : ApiControllerBase
    {

        public PassengerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("/CreatePassenger")]
        public async Task<IActionResult> CreatePassenger([FromBody] CreatePassengerCommand command)
        {
            await Send(command);
            return Ok($"Create passenger with userId: {command.UserId}");
        }

        
    }
}