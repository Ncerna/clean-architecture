using Core.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetAll();
}
