using System;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Repositories;
using EngineeringWork.Infrastructure.Services.DriverService;
using EngineeringWork.Infrastructure.Services.NodeService;
using EngineeringWork.Infrastructure.Services.PassengerRouteService;
using EngineeringWork.Infrastructure.Services.PassengerService;
using EngineeringWork.Infrastructure.Services.Password;
using EngineeringWork.Infrastructure.Services.RouteService;
using EngineeringWork.Infrastructure.Services.UserService;
using Microsoft.Extensions.Logging;

namespace EngineeringWork.Infrastructure.Seed
{
    public class SeedData : ISeedData
    {
        private readonly IDriverService _driverService;

        private readonly IUserService _userService;

        private readonly IDriverRouteService _driverRouteService;

        private readonly ILogger<SeedData> _logger;

        private readonly IDailyRouteService _dailyRouteService;
    
        private readonly IUserRepository _userRepository;

        private readonly IPassengerRouteService _passengerRouteService;

        private readonly IPassengerService _passengerService;
        
        public SeedData(IUserService userService, IDriverService driverService, ILogger<SeedData> logger, IDriverRouteService driverRouteService, INodeManager nodeManager, IUserRepository userRepository,  IDailyRouteService dailyRouteService, IPassengerRouteService passengerRouteService, IPassengerService passengerService)
        {
            _userService = userService;
            _driverService = driverService;
            _dailyRouteService = dailyRouteService;
            _passengerRouteService = passengerRouteService;
            _passengerService = passengerService;
            _logger = logger;
            _driverRouteService = driverRouteService;
            _userRepository = userRepository;
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
                
                await _passengerService.CreatePassenger(userId, new Adress("lublin", "21-500", "karola"));
                _logger.LogInformation($"Passenger with userId: {userId} created async");
                
                var routeStartTime = DateTime.UtcNow;
                var routeId = Guid.NewGuid();
                
                await _dailyRouteService.AddDailyRouteAsync(routeId, userId, 52.21890,  54.36286, 21.23400, 18.60375, routeStartTime);
                _logger.LogInformation($"Route start in {routeStartTime} created async");

                await _passengerRouteService.AddPassengerToRoute(userId, routeId, 52, 54);
                _logger.LogInformation($"Passenger with {userId} are saved to route {routeId}");
                
            }
            _logger.LogTrace("Data was initialized.");  
        }
    }
}