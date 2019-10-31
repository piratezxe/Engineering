using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Repositories;
using EngineeringWork.Infrastructure.DTO;
using EngineeringWork.Infrastructure.Services.NodeService;
using EngineeringWork.Infrastructure.Services.RouteService;
using EngineeringWork.Infrastructure.Services.UserService;

namespace EngineeringWork.Infrastructure.Services.PassengerService
{
    public class PassengerSerivce : IPassengerService
    {
        private readonly IUserService _userService;
        private readonly IPassengerRepository _passengerRepository;
        
        public PassengerSerivce(IPassengerRepository passengerRepository, IUserService userService)
        {
            _passengerRepository = passengerRepository;
            _userService = userService;
        }

        public async Task<Passenger> GetById(Guid passengerId)
        {
            var passenger = await _passengerRepository.GetAsync(passengerId);
            if(passenger is null)
                throw new ArgumentNullException($"Passenger with {passengerId} not exist");
            return passenger;
        }

        public async Task CreatePassenger(Guid userId, Adress adress)
        {
            var user = await _userService.GetAsyncById(userId);
            await _passengerRepository.CreatePassenger(new Passenger(userId, adress));
        }
    }
}