using Core.Application.DTOs;
using Core.Domain.Entities;

namespace Core.Application.Mappings
{
  
    public static class ProductMapping
    {
        public static ProductDto ToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.Value,   
                Stock = product.Stock.Value,  
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
        }
        public static List<ProductDto> ToDtoList(this IEnumerable<Product> products)
        {
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price.Value,
                Stock = p.Stock.Value,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).ToList();
        }
    }
}
