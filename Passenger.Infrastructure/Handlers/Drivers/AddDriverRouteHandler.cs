using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Services.DriverService;
using Passenger.Infrastructure.Services.NodeService;

namespace Passenger.Infrastructure.Handlers.Drivers
{
    public class AddDriverRouteHandler : ICommandHandler<AddDriverRoute>
    {
        private readonly IDriverRouteService _driverRouteService;


        private readonly INodeManager _nodeManager;

        
        public AddDriverRouteHandler(IDriverRouteService driverRouteService, INodeManager nodeManager)
        {
            _driverRouteService = driverRouteService;
            _nodeManager = nodeManager;
        }

        public async Task HandleAsync(AddDriverRoute command)
        {

            await _driverRouteService.AddRouteAsync(Guid.NewGuid(), command.UserId, command.StartLatitude, command.EndLatitude,
                command.StartLongitude, command.EndLongitude, command.StartTime);
        }
    }
}