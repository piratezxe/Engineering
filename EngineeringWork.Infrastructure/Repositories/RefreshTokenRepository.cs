using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.Database;
using Microsoft.EntityFrameworkCore;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class RefreshTokenRepository : ITokenRepository
    {
        private readonly PassengerContext _passengerContext;

        public RefreshTokenRepository(PassengerContext passengerContext)
        {
            _passengerContext = passengerContext;
        }

        public async Task<RefreshToken> GetTokneAsync(string token)
        {
            return await _passengerContext.RefreshTokens.SingleOrDefaultAsync(x => x.Token == token);
        }

        public async Task<IEnumerable<RefreshToken>> BrowseAllAsync()
        {
            return await _passengerContext.RefreshTokens.ToListAsync();
        }

        public async Task CreateAsync(RefreshToken refreshToken)
        {
            await _passengerContext.RefreshTokens.AddAsync(refreshToken);
        }
    }
}