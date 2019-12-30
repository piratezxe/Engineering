using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;

namespace EngineeringWork.Repository.Repositories.Interface
{
    public interface IDailyRouteRepository : IRepository
    {
        Task<DailyRoute> GetAsync(Guid routeId);
        Task CreateAsync(DailyRoute dailyRoute);
        Task<IEnumerable<DailyRoute>> BrowseAsync();
        Task<IEnumerable<DailyRoute>> GetAllAsync();
        Task RemoveAsync(Guid routeId);
        Task UpdateAsync(DailyRoute dailyRoute);
    }
}