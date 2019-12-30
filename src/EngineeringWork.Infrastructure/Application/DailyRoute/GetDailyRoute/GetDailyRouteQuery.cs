using System;
using EngineeringWork.Infrastructure.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.DailyRoute.GetDailyRoute
{
    public class GetDailyRouteQuery : IRequest<DailyRouteDto>
    {
        public Guid Id { get; set; }
    }
}