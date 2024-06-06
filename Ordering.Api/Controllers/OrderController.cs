using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.AddOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrderItem;
using Ordering.Application.Features.Orders.Queries.GetById;


namespace Ordering.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetByIdQuery() { Id = 1 });
        return Ok(result);
    }


    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        var result = await _mediator.Send(new GetByIdQuery() { Id = id });
        return Ok(result);
    }  

    [HttpPost("CreateOrder")]
    public async Task<IActionResult> Post([FromBody] CreateOrderCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("DeleteOrder")]
    public async Task<IActionResult> Delete([FromBody] DeleteOrderCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("DeleteOrderItem")]
    public async Task<IActionResult> Delete([FromBody] DeleteOrderItemCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
