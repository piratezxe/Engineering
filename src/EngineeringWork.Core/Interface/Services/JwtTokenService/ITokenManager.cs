using System.Threading.Tasks;
using EngineeringWork.Core.DTO;

namespace EngineeringWork.Core.Interface.Services.JwtTokenService
{
    public interface ITokenManager : IService
    {
        Task RevokeRefreshTokenAsync(string RefreshToken);

        Task<JwtDto> RefreshAcessTokenAsync(string resfreshToken);
        
    }
}