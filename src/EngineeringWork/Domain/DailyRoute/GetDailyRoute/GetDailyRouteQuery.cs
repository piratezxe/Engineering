using System;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Web.Domain.DailyRoute.GetDailyRoute
{
    public class GetDailyRouteQuery : IRequest<DailyRouteDto>
    {
        public Guid Id { get; set; }
    }
}