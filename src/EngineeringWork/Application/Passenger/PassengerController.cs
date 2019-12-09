using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.DTO;
using EngineeringWork.Web.Application;
using EngineeringWork.Web.Domain.DailyRoute.AddPassengerToRoute;
using EngineeringWork.Web.Domain.DailyRoute.GetPassengerRoute;
using EngineeringWork.Web.Domain.DailyRoute.RemovePassengerFromRoute;
using EngineeringWork.Web.Domain.Passenger.CreatePassenger;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Domain.Passenger
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