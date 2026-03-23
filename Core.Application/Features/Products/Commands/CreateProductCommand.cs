using Core.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Features.Products.Commands;

public record CreateProductCommand(
    string Name,
    decimal Price,
    int Stock
) : IRequest<Response<Guid>>;