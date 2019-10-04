using System;
using System.Threading.Tasks;
using Passenger.Core.Repositories;

namespace EngineeringWork.Core.Repositories
{
    public interface IPassengerRepository : IRepository
    {
        Task CreatePassenger(Domain.Passenger passenger);

        Task<Domain.Passenger> GetAsync(Guid passengerId);
    }
}