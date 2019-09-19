using System;

namespace Passenger.Infrastructure.Commands.Auth
{
    public interface IAuthCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}