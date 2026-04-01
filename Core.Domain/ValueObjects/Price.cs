using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.ValueObjects
{
    public class Price
    {
        public decimal Value { get; }
        public Price(decimal value)
        {
            if (value < 0)
                throw new Exception("Price cannot be negative");

            Value = value;
        }
    }
}
