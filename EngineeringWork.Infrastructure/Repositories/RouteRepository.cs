using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EngineeringWork.Core.Database;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EngineeringWork.Infrastructure.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly PassengerContext _passengerContext;

        public RouteRepository(PassengerContext passengerContext)
        {
            _passengerContext = passengerContext;
        }

        public async Task<IEnumerable<DailyRoute>> GetAsyncByPlace(string departue, string destination)
        {
            var route = await BrowseAsync();
            return route.Where(x =>
                x.Route.StartNode.Address == departue && x.Route.EndNode.Address == destination);
        }

        public async Task<DailyRoute> GetAsync(Guid routeId)
        {
            return await _passengerContext.DailyRoutes.SingleOrDefaultAsync(x => x.Id == routeId);
        }

        public async Task CreateAsync(DailyRoute dailyRoute)
        {
            await _passengerContext.AddAsync(dailyRoute);
            await _passengerContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DailyRoute>> BrowseAsync(Expression<Func<DailyRoute, bool>> predicate = null)
        {
            var query = _passengerContext.Set<DailyRoute>().Include(_passengerContext.GetIncludePaths(typeof(DailyRoute)));
            if (predicate != null)
                query = query.Where(predicate);
            return await query.ToListAsync();        
        }

        public async Task RemoveAsync(Guid routeId)
        {
            var route = GetAsync(routeId);
            _passengerContext.Remove(route);
            await _passengerContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(DailyRoute dailyRoute)
        {
            _passengerContext.DailyRoutes.Update(dailyRoute);
            await _passengerContext.SaveChangesAsync();
        }
    }
}