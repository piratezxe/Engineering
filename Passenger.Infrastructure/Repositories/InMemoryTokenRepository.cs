using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IList<RefreshToken> _refreshTokens;

        public TokenRepository(IList<RefreshToken> refreshTokens)
        {
            _refreshTokens = refreshTokens;
        }

        public async Task<RefreshToken> GetTokneAsync(Guid userId)
        {
            return await Task.FromResult(_refreshTokens.SingleOrDefault(x => x.UserId == userId));
        }

        public async Task<IEnumerable<RefreshToken>> BrowseAllAsync()
        {
            return await Task.FromResult(_refreshTokens);
        }

        public async Task CreateAsync(RefreshToken refreshToken)
        {
            _refreshTokens.Add(refreshToken);
            await Task.CompletedTask;
        }
    }
}