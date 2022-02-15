using System;
using System.Threading.Tasks;

using eCommerce.Application.ShoppingCarts.Commands;
using eCommerce.Application.ShoppingCarts.Queries;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers;

[ApiController]
[ApiVersion("1.0"), Route("v{version:apiVersion}/[controller]")]
public class ShoppingCartController : ControllerBase
{
    private readonly ISender _sender;

    public ShoppingCartController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateShoppingCartAsync()
    {
        var command = CreateShoppingCartCommand.Create();

        var response = await _sender.Send(command);

        return Ok(response);
    }

    [HttpGet("{shoppingCartId}")]
    public async Task<IActionResult> GetShoppingCartAsync(Guid shoppingCartId)
    {
        var query = GetShoppingCartQuery.Create(shoppingCartId);

        var response = await _sender.Send(query);

        return Ok(response);
    }

    [HttpPost("{shoppingCartId}/items")]
    public async Task<IActionResult> AddShoppingCartItemAsync(Guid shoppingCartId, object request)
    {
        var command = AddItemCommand.Create(shoppingCartId, Guid.NewGuid());

        await _sender.Send(command);

        return NoContent();
    }

    [HttpDelete("{shoppingCartId}/items/{itemId}")]
    public async Task<IActionResult> RemoveShoppingCartItemAsync(Guid shoppingCartId, Guid itemId)
    {
        var command = RemoveItemCommand.Create(shoppingCartId, itemId);

        await _sender.Send(command);

        return NoContent();
    }
}