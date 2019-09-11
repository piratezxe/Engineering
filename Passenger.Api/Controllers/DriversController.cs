using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<DriverDto>> GetAll()
        {
            return await _driverService.BrowseAsync();
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDriver command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        } 
        
        [Authorize]
        [HttpPost("/addRoute")]
        public async Task<IActionResult> Post([FromBody]AddDriverRoute command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
        //remove me
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await CommandDispatcher.DispatchAsync(new RemoveDriver());

            return NoContent();
        }
    }
}