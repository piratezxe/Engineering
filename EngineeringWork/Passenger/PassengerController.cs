using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.DTO;
using EngineeringWork.Infrastructure.Commands.Passenger;
using EngineeringWork.Infrastructure.Query.PassengerQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Controllers
{
    public class PassengerController : ApiControllerBase
    {

        public PassengerController(IMediator mediator) : base(mediator)
        {
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

        [HttpPost("/CreatePassenger")]
        public async Task<IActionResult> CreatePassenger([FromBody] CreatePassengerCommand command)
        {
            await Send(command);
            return Ok($"Create passenger with userId: {command.UserId}");
        }
        
        [HttpGet("/GetPassengerRoute")]
        public async Task<IEnumerable<DailyRouteDto>> GetMySavedRoute()
        {
            return await Send<IEnumerable<DailyRouteDto>>(new GetPassengerRouteQuery());
        }

        [HttpGet("/GetPassengerRoute/{userId}")]
        public async Task<IEnumerable<DailyRouteDto>> GetMySavedRoute([FromRoute] Guid userId)
        {
            return await Send<IEnumerable<DailyRouteDto>>(new GetPassengerRouteQuery() { UserId = userId } );
        }
    }
}