using System;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Query.DailyRoute
{
    public class GetDailyRouteQuery : IRequest<DailyRouteDto>
    {
        public Guid Id { get; set; }
    }
}