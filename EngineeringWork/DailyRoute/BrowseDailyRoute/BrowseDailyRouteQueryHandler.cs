using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.DTO;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Query.DailyRoute;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.QueryHandlers.RouteHandler
{
    public class BrowseDailyRouteQueryHandler : IRequestHandler<BrowseDailyRouteQuery, IEnumerable<DailyRouteDto>>
    {
        private readonly IDailyRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public BrowseDailyRouteQueryHandler(IDailyRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DailyRouteDto>> Handle(BrowseDailyRouteQuery request, CancellationToken cancellationToken)
        {
            var routs = await _routeRepository.BrowseAsync(null);
            return _mapper.Map<IEnumerable<DailyRoute>, IEnumerable<DailyRouteDto>>(routs);
        }
    }
}
