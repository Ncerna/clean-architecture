using Core.Application.DTOs;
using Core.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Features.Products.Queries;

public record GetProductByIdQuery(Guid Id) : IRequest<Response<ProductDto>>;