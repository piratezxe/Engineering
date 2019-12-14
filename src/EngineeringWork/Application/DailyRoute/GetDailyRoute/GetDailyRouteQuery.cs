using System;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Web.Application.DailyRoute.GetDailyRoute
{
    public class GetDailyRouteQuery : IRequest<DailyRouteDto>
    {
        public Guid Id { get; set; }
    }
}