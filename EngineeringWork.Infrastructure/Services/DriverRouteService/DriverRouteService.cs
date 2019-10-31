using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Repositories;
using EngineeringWork.Infrastructure.DTO;

namespace EngineeringWork.Infrastructure.Services.DriverService
{
    public class DriverRouteService : IDriverRouteService
    {
        private readonly IRouteRepository _routeRepository;

        private readonly IMapper _mapper;

        public DriverRouteService(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DailyRouteDto>> GetMyDailyRoutes(Guid userId)
        {
            var  dailyRoute = await _routeRepository.BrowseAsync(x => x.DriverId == userId);
            return _mapper.Map<IEnumerable<DailyRoute>, IEnumerable<DailyRouteDto>>(dailyRoute);
        }
    }
}