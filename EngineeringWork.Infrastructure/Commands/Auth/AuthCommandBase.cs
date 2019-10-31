using System;

namespace EngineeringWork.Infrastructure.Commands.Auth
{
    public class AuthCommandBase : IAuthCommand
    {
        public Guid UserId { get; set; }
    }
}