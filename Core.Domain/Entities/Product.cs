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
    public Price Price { get; private set; }
    public Stock Stock { get; private set; }

    private Product() { }

    private Product(string name, string code, decimal priceAmount, int stock)
    {
        Name = name;
        Code = code;
        Price = new Price(priceAmount);
        Stock = new Stock(stock);
    }

    public static Product Create(string name, string code, decimal price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name is required.");

        if (string.IsNullOrWhiteSpace(code))
            throw new DomainException("Code is required.");


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


        Name = name;
        Code = code;
        Price = new Price(price);
        Stock = new Stock(stock);
        UpdateModified();
    }

    public void AddStock(int quantity)
    {
        Stock = Stock.Add(quantity);
        UpdateModified();
    }

    public void ReduceStock(int quantity)
    {
        Stock = Stock.Remove(quantity);
        UpdateModified();
    }
}

