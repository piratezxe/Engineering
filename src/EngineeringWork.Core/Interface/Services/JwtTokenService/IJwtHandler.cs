using System;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.DTO;

namespace EngineeringWork.Core.Interface.Services.JwtTokenService
{
    public interface IJwtHandler
    {
         JwtDto CreateToken(Guid userId, string role);

         RefreshToken CreateRefreshToken(string role, Guid userId);
    }
}