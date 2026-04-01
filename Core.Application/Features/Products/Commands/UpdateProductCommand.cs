using Core.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Features.Products.Commands;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Code,
    decimal Price,
    int Stock
) : IRequest<Response<Guid>>;
