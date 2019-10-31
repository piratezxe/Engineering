using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Infrastructure.DTO;

namespace EngineeringWork.Infrastructure.Services.RouteService
{
    public interface IDailyRouteService : IService
    {
        Task<DailyRouteDto> GetById(Guid routeId);
        Task<IEnumerable<DailyRouteDto>> GetRouteByLocation(string departue, string destination);
        Task AddDailyRouteAsync(Guid routeId, Guid userId, double startLatitude, double endLatitude, double startLongitude,
            double endLongitude, DateTime startTime);
        Task RemoveAsync(Guid routeId);
    }
}