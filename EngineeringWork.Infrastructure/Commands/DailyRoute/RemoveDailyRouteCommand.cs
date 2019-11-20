using System;
using MediatR;

namespace EngineeringWork.Infrastructure.Commands.DailyRoute
{
    public class RemoveDailyRouteCommand : IRequest
    {
        public Guid RouteId { get; set; }
    }
}