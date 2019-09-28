using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services.DriverService;

namespace Passenger.Api.Controllers
{
    public class DriversController : ApiControllerBase
    {
        private readonly IDriverService _driverService;
        
        public DriversController(ICommandDispatcher commandDispatcher, IDriverService driverService) 
            : base(commandDispatcher)
        {
            _driverService = driverService;
        }

        [HttpGet("/{userId}")]
        public async Task<DriverDto> GetById(Guid userId)
        {
            return await _driverService.GetAsync(userId);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var drivers = await _driverService.BrowseAsync();
            if (drivers == null)
            {
            }
            var json = Json(drivers);
            return json;
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDriver command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
        
        //remove me
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await DispatchAsync(new RemoveDriver());

            return NoContent();
        }
    }
}