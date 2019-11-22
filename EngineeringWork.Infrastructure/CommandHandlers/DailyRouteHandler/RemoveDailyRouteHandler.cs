using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Commands.DailyRoute;
using MediatR;

namespace EngineeringWork.Infrastructure.CommandHandlers.DailyRouteHandler
{
    public class RemoveDailyRouteHandler :  IRequestHandler<RemoveDailyRouteCommand>
    {

        private readonly IDailyRouteRepository _routeRepository;

        public RemoveDailyRouteHandler(IDailyRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<Unit> Handle(RemoveDailyRouteCommand request, CancellationToken cancellationToken)
        {
            var route = await _routeRepository.GetAsync(request.RouteId);
            if (route is null)
                throw new ArgumentNullException($"Route with {request.RouteId} not exist");

            await _routeRepository.RemoveAsync(request.RouteId);
            return Unit.Value;;
        }
    }
}