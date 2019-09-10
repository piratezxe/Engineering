using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryDriverRepository : IDriverRepository
    {
        private static ISet<Driver> _drivers = new HashSet<Driver>();
        
        public async Task<Driver> GetAsync(Guid userId)
            => await Task.FromResult(_drivers.SingleOrDefault(x => x.UserId == userId));

        public async Task RemoveAsync(Driver driver)
        {
           await  Task.FromResult(_drivers.Remove(driver));
        }

        public async Task AddAsync(Driver driver)
        {
            _drivers.Add(driver);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Driver>> GetAllAsync()
            => await Task.FromResult(_drivers);

        public async Task UpdateAsync(Driver driver)
        {
            await Task.CompletedTask;
        }
    }
}