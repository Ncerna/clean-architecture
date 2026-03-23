using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain.Exceptions;
using Core.Domain.ValueObjects;
using Core.Domain.Events;
namespace Core.Domain.Entities;

public sealed class Product : DomainEntity
{
    public string Name { get; private set; }

    public string Code { get; private set; }
    public Money Price { get; private set; }

    public int Stock { get; private set; }



    private Product(string name, string code, decimal priceAmount, int stock)
    {
        Name = name;
        Code = code;
        Price = new Money(priceAmount);
        Stock = stock;
    }

    public static Product Create(string name, string code, decimal price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name is required.");

        if (string.IsNullOrWhiteSpace(code))
            throw new DomainException("Code is required.");

        if (price <= 0)
            throw new DomainException("Price must be greater than zero.");

        if (stock < 0)
            throw new DomainException("Stock cannot be negative.");

        var product = new Product(name, code, price, stock);

        // Lanza evento interno al dominio
        product.RaiseEvent(new ProductCreatedDomainEvent(product.Id));

        return product;
    }

    public void Update(string name, string code, decimal price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name is required.");

        if (string.IsNullOrWhiteSpace(code))
            throw new DomainException("Code is required.");

        if (price <= 0)
            throw new DomainException("Price must be greater than zero.");

        if (stock < 0)
            throw new DomainException("Stock cannot be negative.");

        Name = name;
        Code = code;
        Price = new Money(price);
        Stock = stock;
        UpdateModified();
    }

    public void AddStock(int quantity)
    {
        if (quantity <= 0)
            throw new DomainException("Quantity must be greater than zero.");

        Stock += quantity;
        UpdateModified();
    }

    public void ReduceStock(int quantity)
    {
        if (quantity <= 0)
            throw new DomainException("Quantity must be greater than zero.");

        if (Stock < quantity)
            throw new DomainException("Insufficient stock.");

        Stock -= quantity;
        UpdateModified();
    }
}

