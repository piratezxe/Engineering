using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Extensions;
using EngineeringWork.Repository.Repositories.Interface;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.DailyRoute.RemoveDailyRoute
{
    public class RemoveDailyRouteCommandHandler :  IRequestHandler<RemoveDailyRouteCommand>
    {

        private readonly IDailyRouteRepository _routeRepository;

        public RemoveDailyRouteCommandHandler(IDailyRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<Unit> Handle(RemoveDailyRouteCommand request, CancellationToken cancellationToken)
        {
            var route = await _routeRepository.GetOrFailAsync(request.RouteId);
            await _routeRepository.RemoveAsync(request.RouteId);
            return Unit.Value;;
        }
    }
}