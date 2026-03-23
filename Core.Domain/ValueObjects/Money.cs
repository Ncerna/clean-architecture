using Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.ValueObjects;

public class Money : ValueObject
{
    public decimal Amount { get; }

    public Money(decimal amount)
    {
        if (amount < 0)
            throw new DomainException("Money cannot be negative.");

        Amount = amount;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
    }
}
