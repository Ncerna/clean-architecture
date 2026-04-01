using Core.Application.DTOs;
using Core.Application.Features.Products.Queries;
using Core.Application.Mappings;
using Core.Application.Wrappers;
using Core.Application.Repositories;
using MediatR;


namespace Core.Application.Features.Products.Handlers;

public class GetProductByIdHandler
    : IRequestHandler<GetProductByIdQuery, Response<ProductDto>>
{
    private readonly IProductRepository _repository;
    

    public GetProductByIdHandler(IProductRepository repository)
    {
        _repository = repository;
        
    }

    public async Task<Response<ProductDto>> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetById(request.Id);

        if (product is null)
            return Response<ProductDto>.Fail("Product not found");
        var data = ProductMapping.ToDto(product);

        return Response<ProductDto>.Ok(data);
    }
}