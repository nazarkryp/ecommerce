using System.Threading.Tasks;

using eCommerce.Application.Payments.Commands;
using eCommerce.Application.Payments.Queries;
using eCommerce.Request.Dtos.Payments;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers;

[ApiController]
[ApiVersion("1.0"), Route("v{version:apiVersion}/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly ISender _sender;

    public PaymentsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePaymentAsync(CreatePaymentRequest request)
    {
        var command = CreatePaymentCommand.Create(
            request.OrderId,
            request.FirstName,
            request.LastName,
            request.EmailAddress,
            request.PhoneNumber);

        var response = await _sender.Send(command);

        return Ok(response);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetPaymentStatusAsync(string orderId)
    {
        var query = GetPaymentQuery.Create(orderId);

        var response = await _sender.Send(query);

        return Ok(response);
    }
}