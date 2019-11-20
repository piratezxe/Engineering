using System.Collections.Generic;
using EngineeringWork.Core.DTO;
using EngineeringWork.Infrastructure.Commands.Auth;
using MediatR;

namespace EngineeringWork.Infrastructure.Query.PassengerQuery
{
    public class GetPassengerRouteQuery : AuthCommandBase, IRequest<IEnumerable<DailyRouteDto>>
    {
        
    }
}