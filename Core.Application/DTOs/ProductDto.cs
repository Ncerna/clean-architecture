using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public decimal Price { get; set; }

    public int Stock { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}
