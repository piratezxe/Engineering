using System;

namespace EngineeringWork.Core.Domain
{
    public class Adress
    {
        public Adress(string city, string zipCode, string street)
        {
            City = city;
            ZipCode = zipCode;
            Street = street;
            Id = Guid.NewGuid();
        }

        protected Adress()
        {
        }
        
        public Guid Id { get; private set; }

        public string ZipCode { get; private set; }
        
        public string City { get; private set; }
        
        public string Street { get; private set; }
    }
}