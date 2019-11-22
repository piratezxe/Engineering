using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringWork.Core.Domain
{
    public class PassengerBooking
    {
        public Guid Id { get; set; }
        public Passenger Passenger { get; private set; }
        public Booking Booking { get; private set; }
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
