using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.DTO;
using EngineeringWork.Infrastructure.Commands.Drivers;
using EngineeringWork.Infrastructure.Query.DailyRoute;
using EngineeringWork.Infrastructure.Query.Driver;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Controllers
{
    public class DriversController : ApiControllerBase
    {
        public DriversController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpGet("/{userId}")]
        public async Task<DriverDto> GetById(Guid userId)
        {
            return await Send(new GetDriverQuery() {DriverId = userId});
        }
        
        [HttpGet]
        public async Task<IEnumerable<DriverDto>> GetAll()
        {
            return await Send(new BrowseDriverQuery());
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDriverCommand command)
        {
            await Send(command);

            return NoContent();
        }
        //remove me
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await Send(new RemoveDriverCommand());

            return NoContent();
        }
    }
}