using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services.PassengerService
{
    public interface IPassengerService : IService
    {
        Task AddPassengerToRoute(Guid passegerId, Guid routeId, double latitude, double longitude);

        Task RemovePassengerFromRoute(Guid passengerId, Guid routeId);
    }
}