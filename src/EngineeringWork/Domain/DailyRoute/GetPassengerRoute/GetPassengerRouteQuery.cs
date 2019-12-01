using System.Collections.Generic;
using EngineeringWork.Core.DTO;
using EngineeringWork.Web.Domain.Auth;
using MediatR;

namespace EngineeringWork.Web.Domain.DailyRoute.GetPassengerRoute
{
    public class GetPassengerRouteQuery : AuthCommandBase, IRequest<IEnumerable<DailyRouteDto>>
    {
        
    }
}