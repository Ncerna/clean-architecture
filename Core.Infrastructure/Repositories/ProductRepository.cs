using Core.Domain.Entities;
using Core.Application.Repositories;
using Persistence.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAll()
        => await _context.Products.AsNoTracking().ToListAsync();

    public async Task<Product?> GetById(Guid id)
        => await _context.Products.FindAsync(id);

    public async Task<bool> ExistsByName(string name)
        => await _context.Products.AnyAsync(p => p.Name == name);

    public async Task Add(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task Update(Product product)
    {
        _context.Products.Update(product);
    }

    public async Task Remove(Product product)
    {
        _context.Products.Remove(product);
    }
    public IQueryable<Product> GetQueryable()
        => _context.Products.AsNoTracking();


}
