using System;
using Passenger.Core.Domain;
using Passenger.Infrastructure.Commands.Auth;

namespace EngineeringWork.Infrastructure.Commands.Passenger
{
    public class CreatePassenger : AuthCommandBase
    {
        public PassengerAdres Adress { get; set; }
        public class PassengerAdres
        {
            public string ZipCode { get; set; }
        
            public string City { get; set; }
        
            public string Street { get; set; }
        }
    }
}