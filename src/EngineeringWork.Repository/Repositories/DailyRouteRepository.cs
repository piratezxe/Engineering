using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Repository.Database;
using EngineeringWork.Repository.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EngineeringWork.Repository.Repositories
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

        public async Task<IEnumerable<DailyRoute>> BrowseAsync()
        {
            var query = await _passengerContext.DailyRoutes
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