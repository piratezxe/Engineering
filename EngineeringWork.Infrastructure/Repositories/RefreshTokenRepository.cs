using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.Database;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EngineeringWork.Infrastructure.Repositories
{
    public class RefreshTokenRepository : ITokenRepository
    {
        private readonly PassengerContext _passengerContext;

        public RefreshTokenRepository(PassengerContext passengerContext)
        {
            _passengerContext = passengerContext;
        }

        public async Task<RefreshToken> GetTokneAsync(string token)
            => await _passengerContext.RefreshTokens.SingleOrDefaultAsync(x => x.Token == token);

        public async Task<IEnumerable<RefreshToken>> BrowseAllAsync()
            => await _passengerContext.RefreshTokens.ToListAsync();

        public async Task CreateAsync(RefreshToken refreshToken)
            => await _passengerContext.RefreshTokens.AddAsync(refreshToken);
    }
}