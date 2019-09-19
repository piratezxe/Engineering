using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Services.DriverService;

namespace EngineeringWork.Web.Controllers
{
    public class PassengerController : ApiControllerBase
    {
        private readonly IDriverRouteService _driverRouteService;
        
        public PassengerController(ICommandDispatcher commandDispatcher, IDriverRouteService driverRouteService) : base(commandDispatcher)
        {
            _driverRouteService = driverRouteService;
        }

        [HttpGet("{start}/{end}")]
        public async Task<IEnumerable<DailyRouteDto>> GetAsync(string start, string end)
        {
            return await _driverRouteService.GetRouteByLocation(start, end);
        }
    }
}