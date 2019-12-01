using System;
using EngineeringWork.Web.Domain.Auth;

namespace EngineeringWork.Web.Domain.DailyRoute.RemoveDailyRoute
{
    public class RemoveDailyRouteCommand : AuthCommandBase
    {
        public Guid RouteId { get; set; }
    }
}