using System.Collections.Generic;
using EngineeringWork.Infrastructure.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.Users.GetUsers
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}