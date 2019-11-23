using System.Collections.Generic;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Query.DailyRoute
{
    public class GetDailyRouteByLocationQuery : IRequest<IEnumerable<DailyRouteDto>>
    {
        public string StartPlace { get; set; }
        
        public string EndPlace { get; set; }
    }
}