using System;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Web.Application.Users.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}