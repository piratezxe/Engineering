using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringWork.Core.Domain
{
    public class Booking
    {
        public Guid Id { get; private set; }
        public DateTime CreateDate { get; private set; }

        private Booking(Guid id)
        {
            CreateDate = DateTime.UtcNow;
            Id = id;
        }

        public static Booking Create(Guid Id)
            => new Booking(Id);
    }
}
