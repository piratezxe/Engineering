using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;

namespace EngineeringWork.Infrastructure.Services.DriverService
{
    public interface IDriverRouteService : IService
    {

        Task<DailyRouteDto> GetById(Guid Id);

        Task<IEnumerable<DailyRouteDto>> GetRouteByLocation(string departue, string destination);
        Task<IEnumerable<DailyRouteDto>> GetMyDailyRoutes(Guid UserId);
        Task<IEnumerable<DailyRouteDto>> GetPassengerRoute(Guid passengerId);
        Task AdDailyRouteAsync(Guid routeId, Guid userId, double startLatitude, double endLatitude, double startLongitude,
            double endLongitude, DateTime startTime);

        Task RemoveAsync(Guid routeId, Guid driverId);
    }
}