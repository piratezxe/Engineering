using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.DTO;
using EngineeringWork.Web.Application;
using EngineeringWork.Web.Domain.DailyRoute.AddPassengerToRoute;
using EngineeringWork.Web.Domain.DailyRoute.CreateDailyRoute;
using EngineeringWork.Web.Domain.DailyRoute.GetDailyRoute;
using EngineeringWork.Web.Domain.DailyRoute.GetDailyRouteByLocation;
using EngineeringWork.Web.Domain.DailyRoute.GetDriverDailyRoute;
using EngineeringWork.Web.Domain.DailyRoute.GetPassengerRoute;
using EngineeringWork.Web.Domain.DailyRoute.RemoveDailyRoute;
using EngineeringWork.Web.Domain.DailyRoute.RemovePassengerFromRoute;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Domain.DailyRoute
{
    [Authorize]
    public class RouteController : ApiControllerBase
    {
        public RouteController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("/{start}/{end}")]
        public async Task<IEnumerable<DailyRouteDto>> GetAsync(string start, string end)
        {
                return await Send(new GetDailyRouteByLocationQuery() { StartPlace = start, EndPlace = end });
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

        [HttpPost("/AddPassengerToRoute")]
        public async Task<IActionResult> JoinToDailyRoute([FromBody] AddPassengerToRouteCommand command)
        {
            await Send(command);
            return Ok($"Add user with id: {command.UserId} to route with Id : {command.RouteId} ");
        }


        [HttpDelete("/RemovePassengerFromRoute")]
        public async Task<IActionResult> RemovePassengerFromRoute([FromBody] RemovePassengerFromRouteCommand command)
        {
            await Send(command);
            return Ok($"Remove user with {command.UserId} from route with id : {command.RouteId}");
        }
    }
}