using System.Threading.Tasks;

using eCommerce.Application.Orders.Commands;
using eCommerce.Application.Orders.Queries;
using eCommerce.Request.Dtos.Orders;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers;

[ApiController]
[ApiVersion("1.0"), Route("v{version:apiVersion}/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ISender _sender;

    public OrdersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync(CreateOrderRequest request)
    {
        var command = CreateOrderCommand.Create(request.ShoppingCartId);

        var response = await _sender.Send(command);

        return Ok(response);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderAsync(string orderId)
    {
        var query = GetOrderQuery.Create(orderId);

        var response = await _sender.Send(query);

        return Ok(response);
    }
}