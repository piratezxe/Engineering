using System;

namespace EngineeringWork.Infrastructure.Commands.Auth
{
    public interface IAuthCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}