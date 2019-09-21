using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Services.DriverService;
using Passenger.Infrastructure.Services.NodeService;
using Passenger.Infrastructure.Services.PassengerService;

namespace Passenger.Infrastructure.Seed
{
    public class SeedData : ISeedData
    {
        private readonly IDriverService _driverService;

        private readonly IUserService _userService;

        private readonly IEncrypter _encrypter;
        
        private readonly IDriverRouteService _driverRouteService;

        private ILogger<SeedData> _logger;

        private readonly INodeManager _nodeManager;

        private readonly IUserRepository _userRepository;

        private readonly IPassengerService _passengerService;
        
        public SeedData(IUserService userService, IDriverService driverService, IEncrypter encrypter, ILogger<SeedData> logger, IDriverRouteService driverRouteService, INodeManager nodeManager, IUserRepository userRepository, IPassengerService passengerService)
        {
            _userService = userService;
            _driverService = driverService;
            _encrypter = encrypter;
            _logger = logger;
            _driverRouteService = driverRouteService;
            _nodeManager = nodeManager;
            _userRepository = userRepository;
            _passengerService = passengerService;
        }

        public async Task Init()
        {
            var users = await _userRepository.GetAllAsync();
            for (int i = 10; i < 100; i = i + 10)
            {
                
                var password = "karol.pisarzewski";
                var userId = Guid.NewGuid();
                var email = $"karol.pisarzewski{i}@gmail.com";
                
                 await _userService.RegisterAsync(userId, email , $"karol.pisarzewski{i}", password, "user");
                _logger.LogInformation($"User with email: {email} and password {password} created async");
                
                await _driverService.CreateAsync(userId);
                _logger.LogInformation($"Driver with {userId} created async");

                await _driverService.SetVehickle(userId, "bmw", "x5", 5);
                _logger.LogInformation($"Set vehickle for user: {userId}");
                
                var routeStartTime = DateTime.UtcNow;
                var routeId = Guid.NewGuid();
                
                await _driverRouteService.AddRouteAsync(routeId, userId, 52.21890,  54.36286, 21.23400, 18.60375, routeStartTime);
                _logger.LogInformation($"Route start in {routeStartTime} created async");

                await _passengerService.AddPassengerToRoute(userId, routeId, 52, 54);
                _logger.LogInformation($"Passebger with {userId} are saved to route {routeId}");
                
            }
            _logger.LogTrace("Data was initialized.");  
        }
    }
}