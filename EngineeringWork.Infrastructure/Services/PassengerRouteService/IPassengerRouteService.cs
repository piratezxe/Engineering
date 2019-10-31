using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.DTO;

namespace EngineeringWork.Infrastructure.Services.PassengerRouteService
{
    public interface IPassengerRouteService : IService
    {
        Task AddPassengerToRoute(Guid passegerId, Guid routeId, double latitude, double longitude);
        Task RemovePassengerFromRoute(Guid passengerId, Guid routeId);
        Task<IEnumerable<DailyRouteDto>> GetPassengerRoute(Guid passengerId);
    }
}