using System.Threading.Tasks;
using EngineeringWork.Infrastructure.DTO;

namespace EngineeringWork.Infrastructure.Services.JwtTokenService
{
    public interface ITokenManager : IService
    {
        Task RevokeRefreshTokenAsync(string RefreshToken);

        Task<JwtDto> RefreshAcessTokenAsync(string resfreshToken);
        
    }
}