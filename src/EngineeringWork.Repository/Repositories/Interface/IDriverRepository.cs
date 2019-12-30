using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;

namespace EngineeringWork.Repository.Repositories.Interface
{
    public interface IDriverRepository : IRepository
    {
        Task<Driver> GetAsync(Guid driverId);
        Task<IEnumerable<Driver>> GetAllAsync();
        Task RemoveAsync(Driver driver);
        Task AddAsync(Driver driver);
        Task UpdateAsync(Driver driver);
    }
}