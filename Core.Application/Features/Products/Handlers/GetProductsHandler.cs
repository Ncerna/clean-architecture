using Core.Application.DTOs;
using Core.Application.Features.Products.Queries;
using Core.Application.Mappings;
using Core.Application.Wrappers;
using Core.Application.Repositories;
using MediatR;


namespace Core.Application.Features.Products.Handlers;

public class GetProductsHandler
    : IRequestHandler<GetProductsQuery, Response<List<ProductDto>>>
{
    private readonly IProductRepository _repository;

    public GetProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<List<ProductDto>>> Handle(
        GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetAll();
        return Response<List<ProductDto>>.Ok(
            ProductMapping.ToDtoList(products)
            );
    }
}
