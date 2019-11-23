using System.Collections.Generic;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Query.UserQuery
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}