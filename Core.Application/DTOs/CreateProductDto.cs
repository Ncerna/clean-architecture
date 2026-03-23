using Core.Application.Features.Products.Commands;

namespace Core.Application.DTOs;

public class CreateProductDto
{
    public string Name { get; set; } = default!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public CreateProductCommand ToCommand() => new(
         Name, Price, Stock
     );

}
