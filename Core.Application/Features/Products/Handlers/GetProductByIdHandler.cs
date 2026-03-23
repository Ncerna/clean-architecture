using Core.Application.DTOs;
using Core.Application.Features.Products.Queries;
using Core.Application.Wrappers;
using Core.Domain.Repositories;
using MediatR;


namespace Core.Application.Features.Products.Handlers;

public class GetProductByIdHandler
    : IRequestHandler<GetProductByIdQuery, Response<ProductDto>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<ProductDto>> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetById(request.Id);

        if (product is null)
            return Response<ProductDto>.Fail("Product not found");

        var data = _mapper.Map<ProductDto>(product);

        return Response<ProductDto>.Ok(data);
    }
}