using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.DTO;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Query.DailyRoute;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.QueryHandlers.RouteHandler
{
    public class GetDailyRouteByLocationQueryHandler : IRequestHandler<GetDailyRouteByLocationQuery, IEnumerable<DailyRouteDto>>
    {
        private readonly IDailyRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public GetDailyRouteByLocationQueryHandler(IDailyRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DailyRouteDto>> Handle(GetDailyRouteByLocationQuery request, CancellationToken cancellationToken)
        {
            var route = await _routeRepository.BrowseAsync(x => x.Route.StartNode.Address == request.StartPlace && x.Route.EndNode.Address == request.EndPlace);
            var routeByLocation = route.ToList();
            if (!routeByLocation.Any())
                throw new ArgumentException($"Route start at {request.StartPlace} and end at {request.EndPlace} not exist");
            return _mapper.Map<IEnumerable<DailyRoute>, IEnumerable<DailyRouteDto>>(routeByLocation);
        }
    }
}
