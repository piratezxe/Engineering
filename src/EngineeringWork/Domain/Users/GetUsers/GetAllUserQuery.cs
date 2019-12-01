using System.Collections.Generic;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Web.Domain.Users.GetUsers
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}