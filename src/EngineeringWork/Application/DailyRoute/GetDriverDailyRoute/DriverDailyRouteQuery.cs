using System.Collections.Generic;
using EngineeringWork.Core.DTO;
using EngineeringWork.Web.Application.Auth;
using MediatR;

namespace EngineeringWork.Web.Application.DailyRoute.GetDriverDailyRoute
{
    public class DriverDailyRouteQuery : AuthCommandBase, IRequest<IEnumerable<DailyRouteDto>>
    {
    }
}