using System.Collections.Generic;
using EngineeringWork.Core.DTO;
using EngineeringWork.Infrastructure.Commands.Auth;
using MediatR;

namespace EngineeringWork.Infrastructure.Query.DailyRoute
{
    public class DriverDailyRouteCommand : AuthCommandBase, IRequest<IEnumerable<DailyRouteDto>>
    {
    }
}