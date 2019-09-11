using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Passenger.Core.Domain
{
    public class Driver
    {
        public Guid UserId { get; protected set; }
        public Vehicle Vehicle { get; protected set; }

        private ISet<Route> _routes = new HashSet<Route>();

        private ISet<DailyRoute> _dailyRoutes = new HashSet<DailyRoute>();

        public IEnumerable<Route> Routes
        {
            get => Routes;

            set => _routes = new HashSet<Route>(value);
        }
        public IEnumerable<DailyRoute> DailyRoutes
        {
            get => DailyRoutes;

            set => _dailyRoutes = new HashSet<DailyRoute>(value);
        }


        public DateTime UpdatedAt { get; private set; }

        protected Driver() 
        {
        }

        public Driver (Guid userid)
        {
            UserId = userid;
        }

        public void AddRoute(string name, Node start, Node end)
        {
            var route = _routes.SingleOrDefault(x => x.Name == name);
            if(route != null)
                throw new ArgumentException("Route exist");
            _routes.Add(Route.Create(start, end, name));
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveRoute(string name)
        {
            var route = _routes.SingleOrDefault(x => x.Name == name);
            if(route is null)
                throw new ArgumentException("Route not exist");
            _routes.Remove(route);
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetVehickle(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }
    }
}