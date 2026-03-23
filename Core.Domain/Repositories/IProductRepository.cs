using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Repositories;

public interface IProductRepository
{
    IQueryable<Product> GetQueryable();
    Task<List<Product>> GetAll();

    Task<Product?> GetById(Guid id);

    Task<bool> ExistsByName(string name);

    Task Add(Product product);

    Task Update(Product product);

    Task Remove(Product product);
}
