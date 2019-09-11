using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Services.DriverService;

namespace Passenger.Infrastructure.Handlers.Drivers
{
    public class AddDriverRouteHandler : ICommandHandler<AddDriverRoute>
    {
        private readonly IDriverRouteService _driverRouteService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly INodeManager _nodeManager;

        
        public AddDriverRouteHandler(IDriverRouteService driverRouteService, IHttpContextAccessor httpContextAccessor, INodeManager nodeManager)
        {
            _driverRouteService = driverRouteService;
            _httpContextAccessor = httpContextAccessor;
            _nodeManager = nodeManager;
        }

        public async Task HandleAsync(AddDriverRoute command)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var startNodeAdress = await _nodeManager.GetAdrressAsync(command.StartLatitude, command.StartLongitude);
            var endNodeAdress = await _nodeManager.GetAdrressAsync(command.StartLatitude, command.StartLongitude);            
            var routeAdress = await _nodeManager.GetRouteAdrressAsync(command.StartLatitude, command.StartLongitude,
                command.EndLatitude, command.EndLongitude);
            
            await _driverRouteService.AddRouteAsync(new Guid(userId), command.StartLatitude, command.EndLatitude,
                command.StartLongitude, command.EndLongitude, startNodeAdress, endNodeAdress, routeAdress);
        }
    }
}