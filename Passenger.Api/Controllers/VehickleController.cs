using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;

namespace EngineeringWork.Web.Controllers
{
    public class VehickleController : ApiControllerBase
    {
        public VehickleController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }
        
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> SetVehickle([FromBody] SetVehickle command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
    }
}