using System.Threading.Tasks;
using EngineeringWork.Web.Application;
using EngineeringWork.Web.Domain.Drivers.SetDriverVehickle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Domain.Drivers
{
    public class VehickleController : ApiControllerBase
    {
        public VehickleController(IMediator mediator) : base(mediator)
        {
        }
        
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> SetVehickle([FromBody] SetVehickleCommand command)
        {
            await Send(command);
            return NoContent();
        }
    }
}