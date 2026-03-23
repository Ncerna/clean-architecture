using Core.Application.Features.Products.Commands;
namespace Core.Application.DTOs;
public class UpdateProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public UpdateProductCommand ToCommand() => new(
        Id: Id,
        Name: Name,
        Price: Price,
        Stock: Stock
    );
}

