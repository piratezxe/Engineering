using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Repository.Database;
using EngineeringWork.Repository.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EngineeringWork.Repository.Repositories
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