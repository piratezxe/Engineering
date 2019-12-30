using System;
using EngineeringWork.Core.Domain;
using EngineeringWork.Infrastructure.DTO;

namespace EngineeringWork.Infrastructure.Services.JwtTokenService
{
    public interface IJwtHandler
    {
         JwtDto CreateToken(Guid userId, string role);

         RefreshToken CreateRefreshToken(string role, Guid userId);
    }
}