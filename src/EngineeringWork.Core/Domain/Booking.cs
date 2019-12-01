using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringWork.Core.Domain
{
    public class Booking
    {
        public Guid Id { get; private set; }

        public DateTime CreateDate { get; private set; }

        public DateTime UpdateTime { get; private set; }

        public BookingStatus BookingStatus { get; private set; }

        private Booking(Guid id)
        {
            CreateDate = DateTime.UtcNow;
            Id = id;
            BookingStatus = BookingStatus.Send;
        }

        public void ChangeStatus(Booking status)
        {
            if (status.BookingStatus != BookingStatus)
            {
                BookingStatus = status.BookingStatus;
                UpdateTime = DateTime.UtcNow;
            }
        }

        public static Booking Create(Guid Id)
            => new Booking(Id);
    }
}
