using Core.Application.DTOs;
using Core.Application.Wrappers;
using MediatR;
namespace Core.Application.Features.Products.Queries;

public record GetProductByIdQuery(Guid Id) : IRequest<Response<ProductDto>>;