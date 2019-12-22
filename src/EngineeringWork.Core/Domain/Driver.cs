using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace EngineeringWork.Core.Domain
{
    public class Driver
    {
        [Key]
        public Guid DriverId { get; protected set; }
        public string PhoneNumber { get; private set; }
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

        public Driver (Guid userid, string phoneNumber)
        {
            DriverId = userid;
            SetPhoneNumber(phoneNumber);
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Equals(PhoneNumber))
            {
                return;
            }
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentException($"Phone number cannot be empty");
            }
            PhoneNumber = phoneNumber;
        }
        
        public void AddDailyRoute(Guid id, Node start, Node end, DateTime createDate, DateTime startDate, int freeSeats, MoneyValue moneyValue)
        {
            var route = _dailyRoutes.SingleOrDefault(x => x.Id == id);
            if (route != null)
                throw new ArgumentException($"Daily route with id: {id} actual exist");

            if (freeSeats < 1 || freeSeats >= Vehicle.Seats)
                throw new ArgumentException($"Your vehicle have only {freeSeats} ");

            var dailyRoute = DailyRoute.CreateDailyRoute(createDate, startDate, Route.Create(start, end), id, freeSeats, moneyValue);
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

        public void SetVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }
    }
}