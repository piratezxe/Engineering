using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngineeringWork.Core.Database;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Repositories;
using Microsoft.EntityFrameworkCore;
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
            return await _passengerContext.Drivers.SingleOrDefaultAsync(x => x.DriverId == userId);
        }

        public async Task<IEnumerable<Driver>> GetAllAsync()
        {
            var cos = await _passengerContext.Drivers.ToListAsync();
            return cos;
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