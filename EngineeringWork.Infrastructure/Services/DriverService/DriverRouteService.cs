using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services.NodeService;

namespace Passenger.Infrastructure.Services.DriverService
{
    public class DriverRouteService : IDriverRouteService
    {
        
        private readonly IDriverRepository _driverRepository;

        private readonly INodeManager _nodeManager;

        private readonly IDailyRouteRepository _dailyRouteRepository;

        private readonly IMapper _mapper;

        public DriverRouteService(IDriverRepository driverRepository,  INodeManager nodeManager, IDailyRouteRepository dailyRouteRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _nodeManager = nodeManager;
            _dailyRouteRepository = dailyRouteRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<DailyRouteDto>> GetRouteByLocation(string departue, string destination)
        {
            var route = await _dailyRouteRepository.GetAsyncByPlace(departue, destination);
            var routeByLocation = route.ToList();
            if(!routeByLocation.Any())
                throw new ArgumentException($"Route start at {departue} and end at {destination} not exist");
            return _mapper.Map<IEnumerable<DailyRoute>, IEnumerable<DailyRouteDto>>(routeByLocation);
        }

        public async Task AddRouteAsync(Guid Id, Guid userId, double startLatitude, double endLatitude, double startLongitude, double endLongitude,
             DateTime startTime)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if(driver is null)
                throw new ArgumentException($"Driver with {userId} not exist");

            var startNodeAddress = await _nodeManager.GetAdrressAsync(startLatitude, startLongitude);
            var endNodeAdress = await _nodeManager.GetAdrressAsync(startLatitude, endLongitude);
            
            var startNode = Node.Create(startNodeAddress, startLongitude, startLongitude);
            var endNode = Node.Create(endNodeAdress, startLatitude, endLongitude);
            driver.AddDailyRoute(Id, startNode, endNode, startTime);
            await _driverRepository.UpdateAsync(driver);
        }

        public async Task RemoveAsync(Guid routeId, Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if(driver is null)
                throw new ArgumentException($"User with {userId} not exist");
            driver.RemoveDailyRoute(routeId);
            await _driverRepository.UpdateAsync(driver);
        }
    }
}