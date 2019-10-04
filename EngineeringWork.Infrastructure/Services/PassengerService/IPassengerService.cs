using System;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using Passenger.Core.Domain;
using Passenger.Infrastructure.Services;

namespace EngineeringWork.Infrastructure.Services.PassengerService
{
    public interface IPassengerService : IService
    {
        Task AddPassengerToRoute(Guid passegerId, Guid routeId, double latitude, double longitude);

        Task RemovePassengerFromRoute(Guid passengerId, Guid routeId);

        Task CreatePassenger(Guid userId, Adress adress);
    }
}