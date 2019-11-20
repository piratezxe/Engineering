using System;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Query.UserQuery
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}