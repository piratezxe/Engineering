using System.Collections.Generic;
using EngineeringWork.Infrastructure.Application.Auth;
using EngineeringWork.Infrastructure.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.DailyRoute.GetPassengerRoute
{
    public class GetPassengerRouteQuery : AuthCommandBase, IRequest<IEnumerable<DailyRouteDto>>
    {
        
    }
}