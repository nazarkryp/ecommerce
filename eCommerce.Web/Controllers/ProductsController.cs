using System;
using System.Threading.Tasks;

using eCommerce.Application.Products.Queries;
using eCommerce.Request.Dtos.Common;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers;

[ApiController]
[ApiVersion("1.0"), Route("v{version:apiVersion}/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync([FromQuery]PaginationFilter filter)
    {
        var query = GetProductsQuery.Create(filter.Page, filter.Size);

        var response = await _sender.Send(query);

        return Ok(response);
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductAsync(Guid productId)
    {
        var query = GetProductQuery.Create(productId);

        var response = await _sender.Send(query);

        return Ok(response);
    }
}