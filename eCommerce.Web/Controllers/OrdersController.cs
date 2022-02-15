using System.Threading.Tasks;

using eCommerce.Application.Orders.Commands;
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
        return Ok();
    }

    //public class PaymentDetails
    //{
    //    public string merchantAccount { get; set; }
    //    public string merchantDomainName { get; set; }
    //    public string authorizationType { get; set; }
    //    public string merchantSignature { get; set; }
    //    public string orderReference { get; set; }
    //    public string orderDate { get; set; }
    //    public string amount { get; set; }
    //    public string currency { get; set; }
    //    public string productName { get; set; }
    //    public string productPrice { get; set; }
    //    public string productCount { get; set; }
    //    public string clientFirstName { get; set; }
    //    public string clientLastName { get; set; }
    //    public string clientEmail { get; set; }
    //    public string clientPhone { get; set; }
    //    public string language { get; set; }
    //}

    //[HttpGet]
    //public async Task<IActionResult> GetCurrentOrderAsync()
    //{
    //    Int32 unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

    //    var paymentDetails = new PaymentDetails
    //    {
    //        merchantAccount = "test_merch_n1",
    //        merchantDomainName = "www.nazarkryp.ua",
    //        authorizationType = "SimpleSignature",
    //        orderReference = Guid.NewGuid().ToString("N").Substring(0, 6),
    //        orderDate = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString(CultureInfo.InvariantCulture).Split('.')[0],
    //        amount = "1.00",
    //        currency = "UAH",
    //        productName = "Процессор Intel Core i5-4670 3.4GHz",
    //        productPrice = "1",
    //        productCount = "1",
    //        clientFirstName = "Nazarii",
    //        clientLastName = "Krypiak",
    //        clientEmail = "nazarkryp@gmail.com",
    //        clientPhone = "380685293558",
    //        language = "UA"
    //    };

    //    string input = $"{paymentDetails.merchantAccount};" +
    //                   $"{paymentDetails.merchantDomainName};" +
    //                   $"{paymentDetails.orderReference};" +
    //                   $"{paymentDetails.orderDate};" +
    //                   $"{paymentDetails.amount};" +
    //                   $"{paymentDetails.currency};" +
    //                   $"{paymentDetails.productName};" +
    //                   $"{paymentDetails.productCount};" +
    //                   $"{paymentDetails.productPrice}";

    //    var keyBytes = Encoding.UTF8.GetBytes("flk3409refn54t54t*FNJRET");
    //    var data = Encoding.UTF8.GetBytes(input);
    //    var hmac = new HMACMD5(keyBytes);
    //    var hash = hmac.ComputeHash(data);

    //    paymentDetails.merchantSignature = System.BitConverter.ToString(hash).Replace("-", "").ToLower();

    //    return Ok(paymentDetails);
    //}
}