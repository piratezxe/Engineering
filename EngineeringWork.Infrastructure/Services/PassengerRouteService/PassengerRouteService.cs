using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Repositories;
using EngineeringWork.Infrastructure.DTO;
using EngineeringWork.Infrastructure.Services.NodeService;
using EngineeringWork.Infrastructure.Services.PassengerService;

namespace EngineeringWork.Infrastructure.Services.PassengerRouteService
{
    public class PassengerRouteService : IPassengerRouteService
    {
        private readonly IPassengerService _passengerService;
        
        private readonly IRouteRepository _routeRepository;

        private readonly INodeManager _nodeManager;

        private readonly IMapper _mapper;
        
        public PassengerRouteService(IPassengerService passengerService, IRouteRepository routeRepository, INodeManager nodeManager, IMapper mapper)
        {
            _passengerService = passengerService;
            _routeRepository = routeRepository;
            _nodeManager = nodeManager;
            _mapper = mapper;
        }
        public async Task AddPassengerToRoute(Guid passegerId, Guid routeId, double latitude, double longitude)
        {
            var passenger = await _passengerService.GetById(passegerId);
            var route = await _routeRepository.GetAsync(routeId);
            if(route is null)
                throw new ArgumentNullException($"Route with id: {routeId} not exist");
            
            var address = await _nodeManager.GetAdrressAsync(latitude, longitude);
            var node = Node.Create(address, longitude, latitude);
            
            route.AddPassengerNode(passenger, node);
            await _routeRepository.UpdateAsync(route);        
        }
        private async Task<bool> isPassengerExistInRoute(Guid routeId, Guid passengerId)
        {
            var passengerRoute = await GetPassengerRoute(passengerId);
            return passengerRoute.Any(x => x.Route.RouteId == routeId);
        }
        
        public async Task RemovePassengerFromRoute(Guid passengerId, Guid routeId)
        {
            var passenger = await _passengerService.GetById(passengerId);

            var route = await _routeRepository.GetAsync(routeId);
            if(route is null)
                throw new ArgumentException($"Route not exist");

            var result = await isPassengerExistInRoute(route.Id, passengerId);
            if(result)
                throw new ArgumentException($"Passenger with {passenger} not exist in route {routeId}");
            
            route.RemovePassengerNode(passenger);
            await _routeRepository.UpdateAsync(route);
        }

        public async Task<IEnumerable<DailyRouteDto>> GetPassengerRoute(Guid passengerId)
        {
            var dailyRoute = await _routeRepository.BrowseAsync(x => x.PassengerNodes.All(k => k.Passenger.Id == passengerId));
            return _mapper.Map<IEnumerable<DailyRoute>, IEnumerable<DailyRouteDto>>(dailyRoute);
        }
    }
}