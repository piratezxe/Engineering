using System;
using EngineeringWork.Infrastructure.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.Users.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}