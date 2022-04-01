using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using eCommerce.Application.Exceptions;
using eCommerce.Application.Payments.Commands;
using eCommerce.Payments.WayForPay.Configuration;
using eCommerce.Payments.WayForPay.Cryptography;
using eCommerce.Persistence;
using eCommerce.Request.Dtos.Payments;

using MediatR;

using Microsoft.Extensions.Options;

namespace eCommerce.Application.Payments.Handlers
{
    internal class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly WayForPayConfiguration _wayForPayConfiguration;
        private readonly SignatureProvider _signature;

        public CreatePaymentCommandHandler(IOrderRepository orderRepository, IShoppingCartRepository shoppingCartRepository, SignatureProvider signature, IOptions<WayForPayConfiguration> options)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _signature = signature;
            _wayForPayConfiguration = options.Value;
        }

        public async Task<CreatePaymentResult> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderAsync(request.OrderId);

            if (order == null)
            {
                throw new OrderNotFoundException(request.OrderId);
            }
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartAsync(order.ShoppingCartId);

            if (shoppingCart == null)
            {
                throw new ShoppingCartNotFoundException(order.ShoppingCartId);
            }

            var createPaymentResult = new CreatePaymentResult
            {
                MerchantAccount = _wayForPayConfiguration.MerchantAccount,
                MerchantDomainName = _wayForPayConfiguration.MerchantDomainName,
                AuthorizationType = "SimpleSignature",
                OrderReference = request.OrderId.ToString(),
                OrderDate = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString(CultureInfo.InvariantCulture).Split('.')[0],
                Amount = "1.00",
                Currency = _wayForPayConfiguration.Currency,
                ProductName = shoppingCart.Items.Select(e => e.Product.Name).ToArray(),
                ProductPrice = shoppingCart.Items.Select(e => e.Product.Price.ToString(CultureInfo.InvariantCulture)).ToArray(),
                ProductCount = shoppingCart.Items.Select(e => e.Quantity.ToString()).ToArray(),
                ClientFirstName = request.FirstName,
                ClientLastName = request.LastName,
                ClientEmail = request.EmailAddress,
                ClientPhone = request.PhoneNumber,
                Language = _wayForPayConfiguration.Language
            };

            var names = string.Join(';', shoppingCart.Items.Select(e => e.Product.Name).ToArray());
            var counts = string.Join(';', shoppingCart.Items.Select(e => e.Quantity).ToArray());
            var prices = string.Join(';', shoppingCart.Items.Select(e => e.Product.Price.ToString(CultureInfo.InvariantCulture)).ToArray());

            var hashString = _signature.CreateSignature(
                createPaymentResult.MerchantAccount,
                createPaymentResult.MerchantDomainName,
                createPaymentResult.OrderReference,
                createPaymentResult.OrderDate,
                createPaymentResult.Amount,
                createPaymentResult.Currency,
                names,
                counts,
                prices);

            createPaymentResult.MerchantSignature = hashString;

            return createPaymentResult;
        }
    }
}
