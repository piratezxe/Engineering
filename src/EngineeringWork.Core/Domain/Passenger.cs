using System;
using System.Collections.Generic;
using System.Linq;

namespace EngineeringWork.Core.Domain
{
    public class Passenger
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public Address Address { get; protected set; }
        
        public Passenger(Guid userId, Address address)
        {
            Id = userId;
            UserId = userId;
            Address = address;
        }

        private Passenger()
        {

        }
    }
}