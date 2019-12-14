using System.Collections.Generic;
using EngineeringWork.Core.DTO;
using EngineeringWork.Web.Application.Auth;
using MediatR;

namespace EngineeringWork.Web.Application.DailyRoute.GetPassengerRoute
{
    public class GetPassengerRouteQuery : AuthCommandBase, IRequest<IEnumerable<DailyRouteDto>>
    {
        
    }
}