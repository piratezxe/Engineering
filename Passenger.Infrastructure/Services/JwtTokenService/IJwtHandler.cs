using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services.JwtTokenService
{
    public interface IJwtHandler
    {
         JwtDto CreateToken(string email, string role);

         RefreshToken CreateRefreshToken(string role, string email);
    }
}