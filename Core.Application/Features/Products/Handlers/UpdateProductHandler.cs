using Core.Application.Features.Products.Commands;
using Core.Application.Wrappers;
using MediatR;
using Microsoft.Extensions.Logging;

using Core.Domain.Exceptions;
using Core.Application.Repositories;
using Core.Application.Interfaces;

namespace Core.Application.Features.Products.Handlers;

public class UpdateProductHandler
    : IRequestHandler<UpdateProductCommand, Response<Guid>>
{
    private readonly IProductRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UpdateProductHandler> _logger;

    public UpdateProductHandler(
        IProductRepository repository,
        IUnitOfWork unitOfWork,
        ILogger<UpdateProductHandler> logger)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Response<Guid>> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var product = await _repository.GetById(request.Id);

            if (product is null)
                return Response<Guid>.Fail("Product not found");

            product.Update(request.Name,request.Code, request.Price, request.Stock);

            await _repository.Update(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Product updated: {Id}", product.Id);

            return Response<Guid>.Ok(product.Id);
        }
        catch (DomainException ex)
        {
            return Response<Guid>.Fail(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating product");
            return Response<Guid>.Fail("Internal error");
        }
    }
}
