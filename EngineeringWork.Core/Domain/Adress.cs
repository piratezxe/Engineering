using System;
using System.Collections.Generic;

namespace EngineeringWork.Core.Domain
{
    public class Adress : ValueObject<Adress>
    {
        public Adress(string city, string zipCode, string street)
        {
            City = city;
            ZipCode = zipCode;
            Street = street;
            Id = Guid.NewGuid();
        }

        private Adress()
        {
        }
        
        public Guid Id { get; private set; }

        public string ZipCode { get; private set; }
        
        public string City { get; private set; }
        
        public string Street { get; private set; }
        protected override bool EqualsCore(Adress other)
        {
            return City == other.City 
                   && ZipCode == other.ZipCode 
                   && Street == other.Street;
        }

        protected override int GetHashCodeCore()
        {
            int hashCode = Street.GetHashCode();
            hashCode = (hashCode * 397) ^ City.GetHashCode();
            hashCode = (hashCode * 397) ^ ZipCode.GetHashCode();
            return hashCode;
        }

        protected IEnumerable<object> GetEqualityComponents()
        {
            yield return ZipCode;
            yield return City;
            yield return Street;
        }
    }
    
}