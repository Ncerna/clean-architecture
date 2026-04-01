using Core.Application.DTOs;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Products.Queries;
//public record GetProductsQuery() : IRequest<Response<List<ProductDto>>>;
public record GetProductsQuery(
    string? Search,
    int? Page,
    int? PageSize,
    string? SortBy,
    string? SortDirection
) : IRequest<Response<List<ProductDto>>>;
