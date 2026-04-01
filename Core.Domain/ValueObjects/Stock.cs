using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.ValueObjects
{
    public class Stock
    {
        public int Value { get; }

        public Stock(int value)
        {
            if (value < 0)
                throw new Exception("Stock cannot be negative");

            Value = value;
        }

        public Stock Add(int qty) => new Stock(Value + qty);

        public Stock Remove(int qty)
        {
            if (Value - qty < 0)
                throw new Exception("Not enough stock");

            return new Stock(Value - qty);
        }
    }
}
