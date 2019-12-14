using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Web.Application.DailyRoute.BrowseDailyRoute
{
    public class BrowseDailyRouteQuery : IRequest<IQueryable<DailyRouteDto>>
    {
    }
}