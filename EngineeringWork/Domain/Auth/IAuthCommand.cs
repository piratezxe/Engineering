using System;
using MediatR;

namespace EngineeringWork.Web.Domain.Auth
{
    public interface IAuthCommand : IRequest  
    {
        Guid UserId { get; set; }
    }
}