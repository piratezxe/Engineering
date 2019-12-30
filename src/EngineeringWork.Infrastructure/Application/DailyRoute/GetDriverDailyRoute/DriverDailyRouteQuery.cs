using System.Collections.Generic;
using EngineeringWork.Infrastructure.Application.Auth;
using EngineeringWork.Infrastructure.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.DailyRoute.GetDriverDailyRoute
{
    public class DriverDailyRouteQuery : AuthCommandBase, IRequest<IEnumerable<DailyRouteDto>>
    {
    }
}