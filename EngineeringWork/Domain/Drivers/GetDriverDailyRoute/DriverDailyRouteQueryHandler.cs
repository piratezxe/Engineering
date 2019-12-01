using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.DTO;
using EngineeringWork.Core.Interface.Repositories;
using MediatR;

namespace EngineeringWork.Web.Domain.Drivers.GetDriverDailyRoute
{
    public class DriverDailyRouteQueryHandler : IRequestHandler<DriverDailyRouteQuery, IEnumerable<DailyRouteDto>>
    {
        private readonly IDriverRepository _driverRepository;

        private readonly IDailyRouteRepository _routeRepository;

        private readonly IMapper _mapper;

        public DriverDailyRouteQueryHandler(IDriverRepository driverRepository, IMapper mapper, IDailyRouteRepository routeRepository)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
            _routeRepository = routeRepository;
        }
        
        public async Task<IEnumerable<DailyRouteDto>> Handle(DriverDailyRouteQuery request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetAsync(request.UserId);
            if (driver is null) 
                throw new ArgumentNullException($"Driver with id: {request.UserId} not exist");

            var dailyRoute = await _routeRepository.BrowseAsync(x => x.DriverId == request.UserId);
            var dailyRouteDto =  _mapper.Map<IEnumerable<Core.Domain.DailyRoute>, IEnumerable<DailyRouteDto>>(dailyRoute);

            return dailyRouteDto;
        }
    }
}