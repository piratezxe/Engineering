using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services.DriverService
{
    public interface IDriverRouteService : IService
    {
        Task<IEnumerable<DailyRouteDto>> GetRouteByLocation(string departue, string destination);
        Task AddRouteAsync(Guid routeId, Guid userId, double startLatitude, double endLatitude, double startLongitude,
            double endLongitude, DateTime startTime);

        Task RemoveAsync(Guid routeId, Guid driverId);
    }
}