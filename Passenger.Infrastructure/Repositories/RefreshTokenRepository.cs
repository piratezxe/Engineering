using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class RefreshTokenRepository : ITokenRepository
    {
        private readonly ITokenRepository _tokenRepository;

        public RefreshTokenRepository(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<RefreshToken> GetTokneAsync(string token)
        {
            return await _tokenRepository.GetTokneAsync(token);
        }

        public async Task<IEnumerable<RefreshToken>> BrowseAllAsync()
        {
            return await _tokenRepository.BrowseAllAsync();
        }

        public async Task CreateAsync(RefreshToken refreshToken)
        {
            await _tokenRepository.CreateAsync(refreshToken);
        }
    }
}