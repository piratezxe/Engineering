using System;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Commands;
using EngineeringWork.Infrastructure.Commands.Drivers;
using EngineeringWork.Infrastructure.Services.DriverService;
using EngineeringWork.Infrastructure.Services.NodeService;
using EngineeringWork.Infrastructure.Services.RouteService;

namespace EngineeringWork.Infrastructure.Handlers.Drivers
{
    public class AddDriverRouteHandler : ICommandHandler<AddDriverRoute>
    {
        private readonly IDailyRouteService _dailyRouteService;

        private readonly INodeManager _nodeManager;

        
        public AddDriverRouteHandler(IDailyRouteService dailyRouteService, INodeManager nodeManager)
        {
            _dailyRouteService = dailyRouteService;
            _nodeManager = nodeManager;
        }

        public async Task HandleAsync(AddDriverRoute command)
        {

            await _dailyRouteService.AddDailyRouteAsync(Guid.NewGuid(), command.UserId, command.StartLatitude, command.EndLatitude,
                command.StartLongitude, command.EndLongitude, command.StartTime);
        }
    }
}