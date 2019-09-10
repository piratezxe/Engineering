using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services.DriverService
{
    public interface IDriverService : IService
    {
        Task<DriverDto> GetAsync(Guid userId);

        Task CreateAsync(Guid userId);

        Task<IEnumerable<Driver>> BrowseAsync();

        Task RemoveAsync(Guid userId);
    }
}