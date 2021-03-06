using System;
using System.Collections.Generic;

namespace EngineeringWork.Core.Domain
{
    public class Address : ValueObject
    {
        public Address(string city, string zipCode, string street)
        {
            City = city;
            ZipCode = zipCode;
            Street = street;
            Id = Guid.NewGuid();
        }

        private Address()
        {
        }
        
        public Guid Id { get; private set; }

        public string ZipCode { get; private set; }
        
        public string City { get; private set; }
        
        public string Street { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ZipCode;
            yield return City;
            yield return Street;
        }
    }
    
}