using System;
using System.Threading.Tasks;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Core.Interface.Services.UserService;
using EngineeringWork.Infrastructure.Commands.Drivers;
using EngineeringWork.Infrastructure.Commands.Passenger;
using EngineeringWork.Infrastructure.Commands.Users;
using EngineeringWork.Infrastructure.Services.NodeService;
using EngineeringWork.Infrastructure.Services.UserService;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EngineeringWork.Infrastructure.Seed
{
    public class SeedData : ISeedData
    {

        private readonly IUserService _userService;

        private readonly IMediator _mediator;

        private readonly ILogger<SeedData> _logger;

        private readonly IUserRepository _userRepository;

        public SeedData(ILogger<SeedData> logger, 
            INodeManager nodeManager, IUserRepository userRepository,  
             IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
            _logger = logger;
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

                await _mediator.Send(new CreateUser()
                    {Email = email, Password = password, Role = "user", Username = $"karol.pisarzewski{i}", UserId = userId});
                _logger.LogInformation($"User with email: {email} and password {password} created async");

                await _mediator.Send(new CreateDriver() {UserId = userId}); 
                _logger.LogInformation($"Driver with {userId} created async");

                await _mediator.Send(new SetVehickle() {UserId = userId, seats = 5, brand = "bmw", name = "x5"});
                _logger.LogInformation($"Set vehickle for user: {userId}");

                var adress = new CreatePassengerCommand().Adress;
                adress.City = "lublin";
                adress.Street = "21-500";
                adress.ZipCode = "21-500";
                
                var passenger = new CreatePassengerCommand() { UserId = userId,  Adress =  adress };
                await _mediator.Send( passenger );
                _logger.LogInformation($"Passenger with userId: {userId} created async");
                
                var routeStartTime = DateTime.UtcNow;
                var routeId = Guid.NewGuid();
                
                await _mediator.Send(new AddDriverRoute { UserId = userId, StartLatitude = 52.21890, StartLongitude  = 54.36286, EndLatitude = 21.23400, EndLongitude = 18.60375, StartTime = routeStartTime });
                _logger.LogInformation($"Route start in {routeStartTime} created async");

                await _mediator.Send(new AddPassengerToRouteCommand()
                    {Latitude = 52, Longitude = 54, RouteId = routeId, UserId = userId});
                _logger.LogInformation($"Passenger with {userId} are saved to route {routeId}");
                
            }
            _logger.LogTrace("Data was initialized.");  
        }
    }
}