using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.DTO;
using EngineeringWork.Core.Interface.Repositories;
using MediatR;

namespace EngineeringWork.Web.Domain.DailyRoute.BrowseDailyRoute
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
            return _mapper.Map<IEnumerable<Core.Domain.DailyRoute>, IEnumerable<DailyRouteDto>>(routs);
        }
    }
}
