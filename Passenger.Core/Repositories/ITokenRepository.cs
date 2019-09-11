using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Core.Domain;

namespace Passenger.Core.Repositories
{
    public interface ITokenRepository : IRepository
    {
        Task<RefreshToken> GetTokneAsync(string token);

        Task<IEnumerable<RefreshToken>> BrowseAllAsync();

        Task CreateAsync(RefreshToken refreshToken);

    }
}