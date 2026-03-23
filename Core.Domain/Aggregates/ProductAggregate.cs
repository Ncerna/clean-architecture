using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Aggregates;

public class ProductAggregate
{
    public Product Product { get; }

    public ProductAggregate(Product product)
    {
        Product = product;
    }
}
