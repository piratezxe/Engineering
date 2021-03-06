using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Application.DailyRoute.BrowseDailyRoute;
using EngineeringWork.Infrastructure.Application.DailyRoute.CreateDailyRoute;
using EngineeringWork.Infrastructure.Application.DailyRoute.GetDriverDailyRoute;
using EngineeringWork.Infrastructure.Application.DailyRoute.GetPassengerRoute;
using EngineeringWork.Infrastructure.Application.DailyRoute.RemoveDailyRoute;
using EngineeringWork.Infrastructure.DTO;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Controllers
{
    [Authorize]
    public class RouteController : ApiControllerBase
    {
        public RouteController(IMediator mediator) : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        [EnableQuery]
        public async Task<IQueryable<DailyRouteDto>> BrowseAsync()
        {
            return await Send(new BrowseDailyRouteQuery());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDailyRouteCommand command)
        {
            await Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoute([FromBody] RemoveDailyRouteCommand command)
        {
            await Send(command);
            return NoContent();
        }
        [HttpGet("me/routes")]
        public async Task<IEnumerable<DailyRouteDto>> GetAllDailyRoute()
        {
            return await Send<IEnumerable<DailyRouteDto>>(new DriverDailyRouteQuery());
        }

        [HttpGet("me/PassengerRoute")]
        public async Task<IEnumerable<DailyRouteDto>> GetMySavedRoute()
        {
            return await Send<IEnumerable<DailyRouteDto>>(new GetPassengerRouteQuery());
        }
    }
}