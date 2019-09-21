using System;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services.JwtTokenService
{
    public interface IJwtHandler
    {
         JwtDto CreateToken(Guid userId, string role);

         RefreshToken CreateRefreshToken(string role, Guid userId);
    }
}