using System;
using EngineeringWork.Web.Application.Auth;

namespace EngineeringWork.Web.Application.DailyRoute.RemoveDailyRoute
{
    public class RemoveDailyRouteCommand : AuthCommandBase
    {
        public Guid RouteId { get; set; }
    }
}