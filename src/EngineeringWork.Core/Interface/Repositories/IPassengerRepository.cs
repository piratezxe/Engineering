using System;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;

namespace EngineeringWork.Core.Interface.Repositories
{
    public interface IPassengerRepository : IRepository
    {
        Task CreatePassenger(Passenger passenger);

        Task<Passenger> GetAsync(Guid passengerId);

        Task UpdateAsync(Passenger passenger);
    }
}