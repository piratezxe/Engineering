using System;
using System.Threading.Tasks;
using EngineeringWork.Core.Database;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
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
            => await _passengerContext.Passenger.SingleOrDefaultAsync(x => x.Id == passengerId);

        public async Task UpdateAsync(Passenger passenger)
        {
            _passengerContext.Passenger.Update(passenger);
            await _passengerContext.SaveChangesAsync();
        }
    }
}