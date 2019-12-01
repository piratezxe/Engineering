using System;
using System.Threading.Tasks;

namespace EngineeringWork.Core.Interface.Repositories
{
    public interface IPassengerRepository : IRepository
    {
        Task CreatePassenger(Domain.Passenger passenger);

        Task<Domain.Passenger> GetAsync(Guid passengerId);
    }
}