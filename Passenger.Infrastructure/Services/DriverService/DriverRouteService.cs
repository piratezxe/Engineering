using System;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Services.DriverService
{
    public class DriverRouteService : IDriverRouteService
    {
        private readonly IDriverRepository _driverRepository;

        private readonly IUserRepository _userRepository;

        public DriverRouteService(IDriverRepository driverRepository, IUserRepository userRepository)
        {
            _driverRepository = driverRepository;
            _userRepository = userRepository;
        }

        public async Task AddRouteAsync(string email, double startLatitude, double endLatitude, double startLongitude, double endLongitude,
            string startNodeAddress, string endNodeAdress, string routeAdress)
        {
            var user = await _userRepository.GetAsyncByEmail(email);
            if(user is null)
                throw new ArgumentException($"User with {email} not exist");
            
            var driver = await _driverRepository.GetAsync(user.Id);
            if(driver is null)
                throw new ArgumentException($"Driver with {user.Id} not exist");

            var startNode = Node.Create(startNodeAddress, startLongitude, startLongitude);
            var endNode = Node.Create(endNodeAdress, startLatitude, endLongitude);
            driver.AddRoute(routeAdress, startNode, endNode);
        }

        public async Task RemoveAsync(string name, Guid driverId)
        {
            var driver = await _driverRepository.GetAsync(driverId);
            if(driver is null)
                throw new ArgumentException($"Driver with {driverId} not exist");

            driver.RemoveRoute(name);
        }
       
    }
}