using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Products.Commands;

public record CreateProductCommand(
    string Name,
    string Code,
    decimal Price,
    int Stock
) : IRequest<Response<Guid>>;