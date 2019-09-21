using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Passenger.Core.Database;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
namespace Passenger.Infrastructure.Repositories
{
    public class DailyRouteRepository : IDailyRouteRepository
    {
        private readonly PassengerContext _passengerContext;

        public DailyRouteRepository(PassengerContext passengerContext)
        {
            _passengerContext = passengerContext;
        }

        public async Task<IEnumerable<DailyRoute>> GetAsyncByPlace(string departue, string destination)
        {
            var route = await _passengerContext.DailyRoutes.ToListAsync();
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

        public async Task<IEnumerable<DailyRoute>> BrowseAsync()
        {
            return await _passengerContext.DailyRoutes.ToListAsync();
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