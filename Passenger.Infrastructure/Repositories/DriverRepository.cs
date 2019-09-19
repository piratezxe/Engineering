using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Passenger.Core.Database;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly PassengerContext _passengerContext;

        public DriverRepository(PassengerContext passengerContext)
        {
            _passengerContext = passengerContext;
        }

        public async Task<Driver> GetAsync(Guid userId)
        {
            return await _passengerContext.Drivers.SingleOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<IEnumerable<Driver>> GetAllAsync()
        {
            return await _passengerContext.Drivers.ToListAsync();
        }

        public async Task RemoveAsync(Driver driver)
        {
            _passengerContext.Drivers.Remove(driver);
            await _passengerContext.SaveChangesAsync();
        }

        public async Task AddAsync(Driver driver)
        {
            await _passengerContext.Drivers.AddAsync(driver);
            await _passengerContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Driver driver)
        {
            _passengerContext.Drivers.Update(driver);
            await _passengerContext.SaveChangesAsync();
        }
    }
}