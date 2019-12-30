using System.Linq;
using EngineeringWork.Infrastructure.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.DailyRoute.BrowseDailyRoute
{
    public class BrowseDailyRouteQuery : IRequest<IQueryable<DailyRouteDto>>
    {
    }
}