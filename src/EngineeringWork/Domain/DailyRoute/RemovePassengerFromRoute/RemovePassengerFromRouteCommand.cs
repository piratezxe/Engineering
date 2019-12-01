using System;
using EngineeringWork.Web.Domain.Auth;

namespace EngineeringWork.Web.Domain.DailyRoute.RemovePassengerFromRoute
{
    public class RemovePassengerFromRouteCommand : AuthCommandBase
    {
        Guid PassengerId { get; set; }
        public Guid RouteId { get; set; }
    }
}