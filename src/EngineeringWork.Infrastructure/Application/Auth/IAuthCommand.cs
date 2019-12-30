using System;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.Auth
{
    public interface IAuthCommand : IRequest  
    {
        Guid UserId { get; set; }
    }
}