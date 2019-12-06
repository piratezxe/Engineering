using System.Collections.Generic;
using EngineeringWork.Core.DTO;
using EngineeringWork.Web.Domain.Auth;
using MediatR;

namespace EngineeringWork.Web.Domain.DailyRoute.GetDriverDailyRoute
{
    public class DriverDailyRouteQuery : AuthCommandBase, IRequest<IEnumerable<DailyRouteDto>>
    {
    }
}