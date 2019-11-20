using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;

namespace EngineeringWork.Core.Interface.Repositories
{
    public interface ITokenRepository : IRepository
    {
        Task<RefreshToken> GetTokneAsync(string token);

        Task<IEnumerable<RefreshToken>> BrowseAllAsync();

        Task CreateAsync(RefreshToken refreshToken);

    }
}