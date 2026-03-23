using Core.Application.DTOs;
using Core.Application.Features.Products.Queries;
using Core.Application.Wrappers;
using Core.Domain.Entities;
using Core.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Products.Handlers;

public class GetProductsHandler
    : IRequestHandler<GetProductsQuery, Response<PagedResponse<ProductDetailDto>>>
{
    private readonly IProductRepository _repository;

    public GetProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<PagedResponse<ProductDetailDto>>> Handle(
        GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        // 1. Obtener IQueryable<Product> del repositorio
        IQueryable<Product> query = _repository.GetQueryable();

        // 2. Aplicar filtro de búsqueda (Search: nombre o código)
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(p =>
                p.Name.Contains(request.Search) ||
                p.Code.Contains(request.Search));
        }

        // 3. Aplicar orden (sortBy: por ejemplo "Name" o "CreatedAt")
        if (!string.IsNullOrWhiteSpace(request.SortBy))
        {
            // Orden por nombre; ajusta según tus constants o mapeo
            query = request.SortDirection.Equals("desc", StringComparison.OrdinalIgnoreCase)
                ? query.OrderByDescending(p => p.Name)
                : query.OrderBy(p => p.Name);
        }
        else
        {
            query = query.OrderBy(p => p.Name);
        }

        // 4. Total de registros (CountAsync de EF Core, NO AsyncEnumerable)
        int totalCount = await query.CountAsync(cancellationToken);

        // 5. Aplicar paginado
        var products = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        // 6. Mapear a DTO
        var dtos = products.Select(product => product.ADto()).ToList();

        // 7. Construir respuesta paginada
        var pagedResult = new PagedResponse<ProductDetailDto>
        {
            Items = dtos,
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };

        // 8. Devolver el Result/Wrapper
        return Response<PagedResponse<ProductDetailDto>>.Ok(pagedResult);
    }
}
