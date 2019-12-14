using System;
using MediatR;

namespace EngineeringWork.Web.Application.Auth
{
    public interface IAuthCommand : IRequest  
    {
        Guid UserId { get; set; }
    }
}