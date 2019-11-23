using System;
using MediatR;

namespace EngineeringWork.Infrastructure.Commands.Auth
{
    public interface IAuthCommand : IRequest  
    {
        Guid UserId { get; set; }
    }
}