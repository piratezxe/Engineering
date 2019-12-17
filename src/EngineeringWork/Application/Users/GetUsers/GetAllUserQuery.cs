using System.Collections.Generic;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Web.Application.Users.GetUsers
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}