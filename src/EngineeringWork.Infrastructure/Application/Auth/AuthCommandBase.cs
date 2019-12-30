using System;

namespace EngineeringWork.Infrastructure.Application.Auth
{
    public class AuthCommandBase : IAuthCommand
    {
        public Guid UserId { get; set; }
    }
}