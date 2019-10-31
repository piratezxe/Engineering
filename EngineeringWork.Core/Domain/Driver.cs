using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EngineeringWork.Core.Domain
{
    public class Driver
    {
        [Key]
        public Guid DriverId { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        
        private ISet<DailyRoute> _dailyRoutes = new HashSet<DailyRoute>();
       
        public virtual ICollection<DailyRoute> DailyRoutes
        {
            get => _dailyRoutes;

            set => _dailyRoutes = new HashSet<DailyRoute>(value);
        }

        public DateTime UpdatedAt { get; private set; }

        protected Driver() 
        {
        }

        public Driver (Guid userid)
        {
            DriverId = userid;
        }

        public void AddDailyRoute(Guid Id, Node start, Node end, DateTime routeDate)
        {
            var route = _dailyRoutes.SingleOrDefault(x => x.DateTime == routeDate);
            if(route != null)
                throw new ArgumentException("Daily route at this time actual exist");

            var dailyRoute = DailyRoute.CreateDailyRoute(routeDate, Route.Create(start, end), Id);
            _dailyRoutes.Add(dailyRoute);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveDailyRoute(Guid routeId)
        {
            var route = _dailyRoutes.SingleOrDefault(x => x.Id == routeId);
            if(route is null)
                throw new ArgumentException($"Route with {routeId} not exist");

            _dailyRoutes.Remove(route);
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetVehickle(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }
    }
}