using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryTokenRepository : ITokenRepository
    {
        private readonly ISet<RefreshToken> _refreshTokens = new HashSet<RefreshToken>();

        public async Task<RefreshToken> GetTokneAsync(string email)
        {
            return await Task.FromResult(_refreshTokens.SingleOrDefault(x => x.UserEmail.Equals(email)));
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