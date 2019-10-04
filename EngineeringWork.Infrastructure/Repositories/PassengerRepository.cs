using System;
using System.Threading.Tasks;
using EngineeringWork.Core.Database;
using EngineeringWork.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EngineeringWork.Infrastructure.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly PassengerContext _passengerContext;

        public PassengerRepository(PassengerContext passengerContext)
        {
            _passengerContext = passengerContext;
        }

        public async Task CreatePassenger(Core.Domain.Passenger passenger)
        {
            await _passengerContext.Passenger.AddAsync(passenger);
            await _passengerContext.SaveChangesAsync();
        }

        public async Task<Core.Domain.Passenger> GetAsync(Guid passengerId)
        {
            return await _passengerContext.Passenger.SingleOrDefaultAsync(x => x.Id == passengerId);
        }
    }
}