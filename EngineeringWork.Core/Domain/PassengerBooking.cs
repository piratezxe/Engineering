using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EngineeringWork.Core.Domain
{
    public class PassengerBooking
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DailyRouteId { get; set; }
        public DailyRoute DailyRoute { get; set; }
        public Passenger Passenger { get; protected set; }
        public Booking Booking { get; protected set; }
        
        public BookingStatus BookingStatus { get; private set; }

        private PassengerBooking(Passenger passenger, Booking booking)
        {
            Booking = booking;
            Passenger = passenger;
            Id = Guid.NewGuid();
        }

        protected PassengerBooking()
        {
        }

        public static PassengerBooking Create(Passenger passenger, Booking booking)
            => new PassengerBooking(passenger, booking);
    }
}
