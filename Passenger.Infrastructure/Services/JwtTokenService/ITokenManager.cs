using System.Threading.Tasks;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services.JwtTokenService
{
    public interface ITokenManager : IService
    {
        Task RevokeRefreshTokenAsync(string RefreshToken);

        Task<JwtDto> RefreshAcessTokenAsync(string resfreshToken);
        
    }
}