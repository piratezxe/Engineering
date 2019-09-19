using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;

namespace EngineeringWork.Web.Controllers
{
    public class DriverRouteController : ApiControllerBase
    {
        public DriverRouteController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }
        
        [Authorize]
        [HttpPost("/addRoute")]
        public async Task<IActionResult> Post([FromBody]AddDriverRoute command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
        
        [Authorize]
        [HttpDelete("/route")]
        public async Task<IActionResult> DeleteRoute([FromBody] RemoveDriverRoute command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
    }
}