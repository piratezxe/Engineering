using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Repository.Database;
using EngineeringWork.Repository.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EngineeringWork.Repository.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly PassengerContext _passengerContext;

        public DriverRepository(PassengerContext passengerContext)
        {
            _passengerContext = passengerContext;
        }

        public async Task<Driver> GetAsync(Guid driverId)
            => await _passengerContext.Drivers.SingleOrDefaultAsync(x => x.DriverId == driverId);

        public async Task<IEnumerable<Driver>> GetAllAsync()
            => await _passengerContext.Drivers.ToListAsync();

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