using System;
using System.Collections.Generic;
using Passenger.Core.Domain;

namespace EngineeringWork.Core.Domain
{
    public class Passenger
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        
        public Adress Address { get; protected set; }

        public Passenger(Guid userId, Adress adress)
        {
            Id = userId;
            UserId = userId;
            Address = adress;
        }

        protected Passenger()
        {
            
        }
    }
}