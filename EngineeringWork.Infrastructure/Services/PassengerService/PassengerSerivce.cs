using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Repositories;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services.NodeService;

namespace EngineeringWork.Infrastructure.Services.PassengerService
{
    public class PassengerSerivce : IPassengerService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDailyRouteRepository _dailyRouteRepository;
        private readonly INodeManager _nodeManager;
        private readonly IPassengerRepository _passengerRepository;
        public PassengerSerivce(IDailyRouteRepository dailyRouteRepository, IUserRepository userRepository, INodeManager nodeManager, IPassengerRepository passengerRepository)
        {
            _dailyRouteRepository = dailyRouteRepository;
            _userRepository = userRepository;
            _nodeManager = nodeManager;
            _passengerRepository = passengerRepository;
        }

        public async Task AddPassengerToRoute(Guid userId, Guid routeId, double latitude, double longitude)
        {
            var user = await _passengerRepository.GetAsync(userId);
            if(user is null)
                throw new Exception($"User with ${userId} not exist");

            var route = await _dailyRouteRepository.GetAsync(routeId);
            if(route is null)
                throw new ArgumentException($"Route with {routeId} not exist");

            var passenger = await _passengerRepository.GetAsync(userId);
            if(passenger is null)
                throw new ArgumentException($"Passenger with {passenger.Id} not exist");
            
            var address = await _nodeManager.GetAdrressAsync(latitude, longitude);
            var node = Node.Create(address, longitude, latitude);
            
            route.AddPassengerNode(passenger, node);
            await _dailyRouteRepository.UpdateAsync(route);
        }

        public async Task RemovePassengerFromRoute(Guid userId, Guid routeId)
        {
            var passenger = await _passengerRepository.GetAsync(userId);
            if(passenger is null)
                throw new ArgumentException($"Passenger with ${userId} not exist");

            var route = await _dailyRouteRepository.GetAsync(routeId);
            if(route is null)
                throw new ArgumentException($"Route not exist");

            
            if (route.PassengerNodes.Any(x => x.Passenger.Id == userId) == false)
                throw new ArgumentException($"Passenger with {userId} not exist in route {routeId}");
            
            route.RemovePassengerNode(passenger);
            await _dailyRouteRepository.UpdateAsync(route);
        }

        public async Task CreatePassenger(Guid userId, Adress adress)
        {
            var user = await _userRepository.GetAsync(userId);
            if(user is null)
                throw new ArgumentException($"User with {userId} not exist");

            await _passengerRepository.CreatePassenger(new Core.Domain.Passenger(userId, adress));
        }
    }
}