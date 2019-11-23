using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Query.DailyRoute
{
    public class BrowseDailyRouteQuery : IRequest<IEnumerable<DailyRouteDto>>
    {
        public Expression<Func<Core.Domain.DailyRoute, bool>> predicate = null;
    }
}