using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.DTO;
using EngineeringWork.Infrastructure.Commands.DailyRoute;
using EngineeringWork.Infrastructure.Commands.Drivers;
using EngineeringWork.Infrastructure.Query.DailyRoute;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Controllers
{
    public class RouteController : ApiControllerBase
    {
        public RouteController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpGet("/{id}")]
        public async Task<DailyRouteDto> GetById(Guid id)
        {
            return await Send(new GetDailyRouteQuery() {Id = id});
        }
      
        [HttpGet("/{start}/{end}")]
        public async Task<IEnumerable<DailyRouteDto>> GetAsync(string start, string end)
        {
            return await Send(new GetDailyRouteByLocationQuery() { StartPlace = start, EndPlace = end });
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDailyRouteCommand command)
        {
            await Send(command);
            return NoContent();
        }
        
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteRoute([FromBody] RemoveDailyRouteCommand command)
        {
            await Send(command);
            return NoContent();
        }

        [Authorize]
        [HttpGet("route/{driverId}")]
        public async Task<IEnumerable<DailyRouteDto>> GetAllDailyRoute([FromRoute]Guid driverId)
        {
            return await Send<IEnumerable<DailyRouteDto>>(new DriverDailyRouteQuery() { UserId = driverId });
        }
        [Authorize]
        [HttpGet("route")]
        public async Task<IEnumerable<DailyRouteDto>> GetAllDailyRoute()
        {
            return await Send<IEnumerable<DailyRouteDto>>(new DriverDailyRouteQuery());
        }
    }
}