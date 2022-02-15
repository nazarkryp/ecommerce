using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

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
        private WayForPayConfiguration _wayForPayConfiguration;
        private readonly SignatureProvider _signature;

        public CreatePaymentCommandHandler(IOrderRepository orderRepository, IShoppingCartRepository shoppingCartRepository, SignatureProvider signature, IOptions<WayForPayConfiguration> options)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _signature = signature;
            _wayForPayConfiguration = options.Value;
        }

        public Task<CreatePaymentResult> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var createPaymentResult = new CreatePaymentResult
            {
                MerchantAccount = _wayForPayConfiguration.MerchantAccount,
                MerchantDomainName = _wayForPayConfiguration.MerchantDomainName,
                AuthorizationType = "SimpleSignature",
                OrderReference = request.OrderId.ToString(),
                OrderDate = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString(CultureInfo.InvariantCulture).Split('.')[0],
                Amount = "1.00",
                Currency = _wayForPayConfiguration.Currency,
                ProductName = "Процессор Intel Core i5-4670 3.4GHz",
                ProductPrice = "1",
                ProductCount = "1",
                ClientFirstName = request.FirstName,
                ClientLastName = request.LastName,
                ClientEmail = request.EmailAddress,
                ClientPhone = request.PhoneNumber,
                Language = _wayForPayConfiguration.Language
            };

            var hashString = _signature.CreateSignature(
                createPaymentResult.MerchantAccount,
                createPaymentResult.MerchantDomainName,
                createPaymentResult.OrderReference,
                createPaymentResult.OrderDate,
                createPaymentResult.Amount,
                createPaymentResult.Currency,
                createPaymentResult.ProductName,
                createPaymentResult.ProductCount,
                createPaymentResult.ProductPrice);

            createPaymentResult.MerchantSignature = hashString;

            return Task.FromResult(createPaymentResult);
        }
    }
}
