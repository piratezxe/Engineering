using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Repositories;
using EngineeringWork.Infrastructure.DTO;
using EngineeringWork.Infrastructure.Services.NodeService;

namespace EngineeringWork.Infrastructure.Services.RouteService
{
    public class DailyRouteService : IDailyRouteService
    {
        private readonly IRouteRepository _routeRepository;

        private readonly IMapper _mapper;

        private readonly IDriverRepository _driverRepository;

        private readonly INodeManager _nodeManager;
        
        public DailyRouteService(IRouteRepository routeRepository, IMapper mapper, IDriverRepository driverRepository, INodeManager nodeManager)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
            _driverRepository = driverRepository;
            _nodeManager = nodeManager;
        }
        public async Task<DailyRouteDto> GetById(Guid routeId)
        {
            var dailyRoute = await _routeRepository.GetAsync(routeId);
            if(dailyRoute is null)
                throw new ArgumentNullException($"Route with {routeId} not exist");
            return _mapper.Map<DailyRoute, DailyRouteDto>(dailyRoute);
        }

        public async Task<IEnumerable<DailyRouteDto>> GetRouteByLocation(string departue, string destination)
        {
            var route = await _routeRepository.GetAsyncByPlace(departue, destination);
            var routeByLocation = route.ToList();
            if(!routeByLocation.Any())
                throw new ArgumentException($"Route start at {departue} and end at {destination} not exist");
            return _mapper.Map<IEnumerable<DailyRoute>, IEnumerable<DailyRouteDto>>(routeByLocation);
        }

        public async Task AddDailyRouteAsync(Guid routeId, Guid userId, double startLatitude, double endLatitude, double startLongitude,
            double endLongitude, DateTime startTime)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if(driver is null)
                throw new ArgumentException($"Driver with {userId} not exist");

            var startNodeAddress = await _nodeManager.GetAdrressAsync(startLatitude, startLongitude);
            var endNodeAdress = await _nodeManager.GetAdrressAsync(startLatitude, endLongitude);
            
            var startNode = Node.Create(startNodeAddress, startLongitude, startLongitude);
            var endNode = Node.Create(endNodeAdress, startLatitude, endLongitude);
            driver.AddDailyRoute(routeId, startNode, endNode, startTime);
            await _driverRepository.UpdateAsync(driver);
        }

        public async Task RemoveAsync(Guid routeId)
        {
            var route = await _routeRepository.GetAsync(routeId);
            if(route is null)
                throw new ArgumentNullException($"Route with {routeId} not exist");

            await _routeRepository.RemoveAsync(routeId);
        }
    }
}