using Core.Application.Features.Products.Commands;
using Core.Application.Interfaces;
using Core.Application.Wrappers;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Application.Features.Products.Handlers;

public class CreateProductHandler
    : IRequestHandler<CreateProductCommand, Response<Guid>>
{
    private readonly IProductRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateProductHandler> _logger;

    public CreateProductHandler(
        IProductRepository repository,
        IUnitOfWork unitOfWork,
        ILogger<CreateProductHandler> logger)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Response<Guid>> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        try
        {

            var product = Product.Create(  request.Name,  request.Code,
                request.Price,  request.Stock
                
            );
            var exists = await _repository.ExistsByName(request.Name);

            if (exists)  return Response<Guid>.Fail("Product already exists");

            await _repository.Add(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Product created: {Id}", product.Id);

            return Response<Guid>.Ok(product.Id);
        }
        catch (DomainException ex)
        {
            return Response<Guid>.Fail(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating product");
            return Response<Guid>.Fail("Internal error");
        }
    }
}

