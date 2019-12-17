using System;
using EngineeringWork.Web.Application.Auth;

namespace EngineeringWork.Web.Application.DailyRoute.RemovePassengerFromRoute
{
    public class RemovePassengerFromRouteCommand : AuthCommandBase
    {
        Guid PassengerId { get; set; }
        public Guid RouteId { get; set; }
    }
}