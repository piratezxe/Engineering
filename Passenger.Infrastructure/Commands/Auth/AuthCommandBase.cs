using System;

namespace Passenger.Infrastructure.Commands.Auth
{
    public class AuthCommandBase : IAuthCommand
    {
        public Guid UserId { get; set; }
    }
}