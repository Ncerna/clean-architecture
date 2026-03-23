using MediatR;
using Microsoft.AspNetCore.Mvc;
using Core.Application.Features.Products.Commands;
using Core.Application.Features.Products.Queries;
using Core.Application.DTOs;

namespace Core.WebAP.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetProductsQueryDto dto)
    {
        var query = dto.ToQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProductDto createProductDto)
    {
        var command = createProductDto.ToCommand();
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDto dto)
    {
        var command = dto.ToCommand() with { Id = id };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

}