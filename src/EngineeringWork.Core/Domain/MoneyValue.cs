using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EngineeringWork.Core.Domain
{
    public class MoneyValue : ValueObject
    {
        public decimal Value { get; }

        public string Currency { get; }

        public MoneyValue(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        protected MoneyValue()
        {

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Currency;
        }
    }
}