using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services.NodeService;

namespace Passenger.Infrastructure.Services.PassengerService
{
    public class PassengerSerivce : IPassengerService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDailyRouteRepository _dailyRouteRepository;
        private readonly INodeManager _nodeManager;

        public PassengerSerivce(IDailyRouteRepository dailyRouteRepository, IUserRepository userRepository, INodeManager nodeManager)
        {
            _dailyRouteRepository = dailyRouteRepository;
            _userRepository = userRepository;
            _nodeManager = nodeManager;
        }

        public async Task AddPassengerToRoute(Guid passegerId, Guid routeId, double latitude, double longitude)
        {
            var user = await _userRepository.GetAsync(passegerId);
            if(user is null)
                throw new Exception($"Passenger with ${passegerId} not exist");

            var route = await _dailyRouteRepository.GetAsync(routeId);
            if(route is null)
                throw new InvalidEnumArgumentException();

            var passenger = new Core.Domain.Passenger(passegerId);
            var address = await _nodeManager.GetAdrressAsync(latitude, longitude);
            var node = Node.Create(address, longitude, latitude);
            
            route.AddPassengerNode(passenger, node);
            
        }

        public async Task RemovePassengerFromRoute(Guid passengerId, Guid routeId)
        {
            var user = await _userRepository.GetAsync(passengerId);
            if(user is null)
                throw new ArgumentException();

            var route = await _dailyRouteRepository.GetAsync(routeId);
            if(route is null)
                throw new ArgumentException();
            
            var passenger = new Core.Domain.Passenger(passengerId);
            route.RemovePassengerNode(passenger);
        }
    }
}