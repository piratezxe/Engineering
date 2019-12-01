using System;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Web.Domain.Users.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}