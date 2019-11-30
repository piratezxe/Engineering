using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EngineeringWork.Core.Domain
{
    public class DailyRoute
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DriverId { get; set; }
        public DateTime DateTime { get; protected set; }
        private ISet<PassengerBooking> _passengerBooking = new HashSet<PassengerBooking>();
        public Route Route { get; protected set; }
        public int FreeSeats { get; private set; }
        

        public virtual ICollection<PassengerBooking> PassengerBookings 
        {
            get => _passengerBooking;
            set => new HashSet<PassengerBooking>(value);
        } 

        public DailyRoute()
        {
        }
        
        protected DailyRoute(DateTime dateTime, Route route, Guid id, int freeSeats)
        {
            Id = id;
            Route = route;
            DateTime = dateTime;
            FreeSeats = freeSeats;
        }

        public void AddPassengerBooking(Passenger passenger, Booking booking)
        {
            var passengerBooking = GetPassengerBooking(passenger);
            if(passengerBooking != null)
            {
                throw new InvalidOperationException($"Passeger: '{passenger.UserId}' already exist in route");
            }
            if (FreeSeats > 0)
            {
                _passengerBooking.Add(PassengerBooking.Create(passenger, booking));
                FreeSeats--;
            }
            throw new ArgumentException("No empty seats");
        }

        public void RemovePassengerBooking(Passenger passenger)
        {
            var passengerBooking = GetPassengerBooking(passenger);
            if(passengerBooking is null)
            {
                return;
            }
            _passengerBooking.Remove(passengerBooking);
            FreeSeats++;
        } 

        private PassengerBooking GetPassengerBooking(Passenger passenger)
            => _passengerBooking.SingleOrDefault(x => x.Passenger.Id == passenger.Id);

        public static DailyRoute CreateDailyRoute(DateTime dateTime, Route route, Guid Id, int FreeSeats)
            => new DailyRoute(dateTime, route,  Id, FreeSeats);
    }
}