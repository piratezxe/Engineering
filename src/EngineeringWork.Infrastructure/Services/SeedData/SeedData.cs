using System;
using System.Linq;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Infrastructure.Application.DailyRoute.CreateDailyRoute;
using EngineeringWork.Infrastructure.Application.Drivers.CreateDriver;
using EngineeringWork.Infrastructure.Application.Drivers.SetDriverVehickle;
using EngineeringWork.Infrastructure.Application.Passenger.CreatePassenger;
using EngineeringWork.Infrastructure.Application.PassengerBookingProposal.CreatePassengerBookingProposal;
using EngineeringWork.Infrastructure.Application.Users.CreateUser;
using EngineeringWork.Repository.Repositories.Interface;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EngineeringWork.Infrastructure.Services.SeedData
{
    public class SeedData : ISeedData
    {
        private readonly IMediator _mediator;

        private readonly ILogger<SeedData> _logger;

        private readonly IUserRepository _userRepository;
        public SeedData(ILogger<SeedData> logger, IUserRepository userRepository, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task Init()
        {
            var users = await _userRepository.GetAllAsync();

            if (users.Any())
            {
                _logger.LogTrace("Data was already initialized");
                return;
            }

            for (int i = 10; i < 100; i = i + 10)
            {

                var password = "karol.pisarzewski";
                var userId = Guid.NewGuid();
                var email = $"karol.pisarzewski{i}@gmail.com";

                await _mediator.Send(new CreateUserCommand()
                {
                    Email = email,
                    Password = password,
                    Username = $"karol.pisarzewski{i}",
                    UserId = userId,
                });
                _logger.LogTrace($"User with email: {email} and password {password} created async");

                await _mediator.Send(new CreateDriverCommand("123123123") {UserId = userId});
                
                _logger.LogTrace($"Driver with {userId} created async");

                await _mediator.Send(new SetVehickleCommand()
                {
                    UserId = userId,
                    seats = 5,
                    brand = "bmw",
                    name = "x5"
                });
                _logger.LogTrace($"Set vehickle for user: {userId}");

                await _mediator.Send(new CreatePassengerCommand()
                {
                    Adress = new CreatePassengerCommand.PassengerAdres()
                    {
                        City = "lublin",
                        ZipCode = "21-500",
                        Street = "Sidorksa"
                    },
                    UserId = userId
                });
                _logger.LogTrace($"Passenger with userId: {userId} created async");

                var routeStartTime = DateTime.UtcNow;
                var routeId = Guid.NewGuid();

                await _mediator.Send(new CreateDailyRouteCommand
                {
                    UserId = userId,
                    StartLatitude = 52.21890,
                    StartLongitude = 54.36286,
                    EndLatitude = 21.23400,
                    EndLongitude = 18.60375,
                    StartDateTime = routeStartTime,
                    MoneyValue = new MoneyValue(12, "PLN"),
                    CreateDateTime = DateTime.Now,
                    FreeSeats = 4,
                    RouteId = routeId
                });
                _logger.LogTrace($"Route start in {routeStartTime} created async");

                await _mediator.Send(new CreatePassengerBookingProposalCommand(routeId, 4, userId));
            }
            _logger.LogTrace("Data was initialized.");
        }
    }
}