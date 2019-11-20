using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.DTO;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Query.DailyRoute;
using EngineeringWork.Infrastructure.Query.Driver;
using MediatR;

namespace EngineeringWork.Infrastructure.QueryHandlers.DriverHandler
{
    public class DriverHandler : IRequestHandler<GetDriverQuery, DriverDto>, IRequestHandler<BrowseDriverQuery, IEnumerable<DriverDto>>
    {
        private readonly IDriverRepository _driverRepository;

        private readonly IRouteRepository _routeRepository;

        private readonly IMapper _mapper;

        public DriverHandler(IDriverRepository driverRepository, IMapper mapper, IRouteRepository routeRepository)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
            _routeRepository = routeRepository;
        }

        public async Task<DriverDto> Handle(GetDriverQuery request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetAsync(request.DriverId);
            return _mapper.Map<Driver,DriverDto>(driver);        
        }

        public async Task<IEnumerable<DriverDto>> Handle(BrowseDriverQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _driverRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverDto>>(drivers);
        }
        
        public async Task<IEnumerable<DailyRouteDto>> Handle(DriverDailyRouteCommand request, CancellationToken cancellationToken)
        {
            var  dailyRoute = await _routeRepository.BrowseAsync(x => x.DriverId == request.UserId);
            return _mapper.Map<IEnumerable<DailyRoute>, IEnumerable<DailyRouteDto>>(dailyRoute);
        }
    }
}