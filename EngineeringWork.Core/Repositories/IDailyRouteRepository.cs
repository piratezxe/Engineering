using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using Passenger.Core.Domain;

namespace Passenger.Core.Repositories
{
    public interface IDailyRouteRepository : IRepository
    {
        Task<DailyRoute> GetAsync(Guid routeId);
        Task<IEnumerable<DailyRoute>> GetAsyncByPlace(string departue, string destination);
        Task CreateAsync(DailyRoute dailyRoute);
        Task<IEnumerable<DailyRoute>> BrowseAsync(Expression<Func<DailyRoute, bool>> predicate);
        Task RemoveAsync(Guid routeId);
        Task UpdateAsync(DailyRoute dailyRoute);
    }
}