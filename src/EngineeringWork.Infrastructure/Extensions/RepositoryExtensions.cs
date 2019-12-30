using System;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Repository.Repositories.Interface;

namespace EngineeringWork.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<User> GetOrFailAsync(this IUserRepository userRepository, Guid id)
        {
            var user = await userRepository.GetAsync(id);
            if(user == null)
                throw new ArgumentNullException($"User with {id} not exist");

            return user;
        }
        
        public static async Task<User> GetOrFailAsync(this IUserRepository userRepository, string  email)
        {
            var user = await userRepository.GetAsyncByEmail(email);
            if(user == null)
                throw new ArgumentNullException($"User with email: {email} not exist");

            return user;
        }
        
        public static async Task<Driver> GetOrFailAsync(this IDriverRepository driverRepository, Guid id)
        {
            var user = await driverRepository.GetAsync(id);
            if(user == null)
                throw new ArgumentNullException($"Driver with {id} not exist");

            return user;
        }
        
        public static async Task<DailyRoute> GetOrFailAsync(this IDailyRouteRepository dailyRouteRepository, Guid id)
        {
            var dailyRoute = await dailyRouteRepository.GetAsync(id);
            if(dailyRoute == null)
                throw new ArgumentNullException($"DailyRoute with {id} not exist");

            return dailyRoute;
        }
        
        public static async Task<PassengerBookingProposal> GetOrFailAsync(this IPassengerBookingProposalRepository passengerBookingProposalRepository, Guid id)
        {
            var passengerBookingProposal = await passengerBookingProposalRepository.GetAsync(id);
            if(passengerBookingProposal == null)
                throw new ArgumentNullException($"Passenger Booking Proposal with {id} not exist");

            return passengerBookingProposal;
        }
    }
}