using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.DTO;

namespace EngineeringWork.Infrastructure.Services.DriverService
{
    public interface IDriverService : IService
    {
        Task<DriverDto> GetAsync(Guid userId);

        Task CreateAsync(Guid userId);

        Task<IEnumerable<DriverDto>> BrowseAsync();

        Task SetVehickle(Guid userId, string brand, string name, int seats);

        Task RemoveAsync(Guid userId);
    }
}