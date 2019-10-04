using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.Database;
using Microsoft.EntityFrameworkCore;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PassengerContext _passengerContext;

        public UserRepository(PassengerContext passengerContext)
        {
            _passengerContext = passengerContext;
        }

        public async Task<User> GetAsync(Guid id)
            => await _passengerContext.Users.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsyncByEmail(string email)
            => await _passengerContext.Users.SingleOrDefaultAsync(x => x.Email.Equals(email));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _passengerContext.Users.ToListAsync();
        
        public async Task AddAsync(User user)
        {
            await _passengerContext.Users.AddAsync(user);
            await _passengerContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _passengerContext.Update(user);
            await _passengerContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = GetAsync(id);
            _passengerContext.Remove(user);
            await _passengerContext.SaveChangesAsync();
        }
    }
}