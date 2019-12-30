using System;
using EngineeringWork.Infrastructure.Application.Auth;

namespace EngineeringWork.Infrastructure.Application.DailyRoute.RemoveDailyRoute
{
    public class RemoveDailyRouteCommand : AuthCommandBase
    {
        public Guid RouteId { get; set; }
    }
}