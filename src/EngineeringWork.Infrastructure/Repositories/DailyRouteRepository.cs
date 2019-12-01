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
    public class DailyRouteRepository : IDailyRouteRepository
    {
        private readonly PassengerContext _passengerContext;

        public DailyRouteRepository(PassengerContext passengerContext)
        {
            _passengerContext = passengerContext;
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
            var query = await _passengerContext.DailyRoutes.Where(predicate)
                .Include(x => x.PassengerBookings)
                    .ThenInclude(x => x.Passenger)
                .Include(x => x.Route)
                    .ThenInclude(x => x.StartNode)
                .Include(x => x.Route)
                    .ThenInclude(x => x.EndNode)
                    .ToListAsync();
            return query;        
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

        public async Task<IEnumerable<DailyRoute>> GetAllAsync()
            => await _passengerContext.DailyRoutes.ToListAsync();
    }
}