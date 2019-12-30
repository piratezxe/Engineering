using System;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Infrastructure.Extensions;
using EngineeringWork.Repository.Repositories.Interface;

namespace EngineeringWork.Infrastructure.Services.PassengerBookingService
{
    public class PassengerBookingService : IPassengerBookingService
    {
        private readonly IDailyRouteRepository _dailyRouteRepository;

        private readonly IPassengerBookingProposalRepository _passengerBookingProposalRepository;

        private readonly IDriverRepository _driverRepository;

        private readonly IUserRepository _userRepository;

        private readonly IPassengerBookingRepository _passengerBookingRepository;


        public PassengerBookingService(
            IPassengerBookingProposalRepository passengerBookingProposalRepository,
            IDailyRouteRepository dailyRouteRepository,
            IDriverRepository driverRepository, IUserRepository userRepository,
            IPassengerBookingRepository passengerBookingRepository)
        {
            _passengerBookingProposalRepository = passengerBookingProposalRepository;
            _dailyRouteRepository = dailyRouteRepository;
            _driverRepository = driverRepository;
            _userRepository = userRepository;
            _passengerBookingRepository = passengerBookingRepository;
        }

        public async Task CreateAsync(Guid id, Guid proposalId)
        {
            var proposal = await _passengerBookingProposalRepository.GetOrFailAsync(proposalId);
            var dailyRoute = await _dailyRouteRepository.GetOrFailAsync(proposal.DailyRouteId);
            var driver = await _driverRepository.GetOrFailAsync(dailyRoute.DriverId);
            var user = await _userRepository.GetOrFailAsync(proposal.UserProposalId);

            var passengerBooking = new PassengerBooking(proposalId, id, driver.PhoneNumber, true, 
                user.Username, dailyRoute.Route.StartNode.Address,
                dailyRoute.Route.EndNode.Address, dailyRoute.StartDate);

            await _passengerBookingRepository.CreateAsync(passengerBooking);
        }
    }
}