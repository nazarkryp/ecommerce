using System;
using System.Threading;
using System.Threading.Tasks;

using eCommerce.Application.Exceptions;
using eCommerce.Application.Payments.Queries;
using eCommerce.Payments.WayForPay;
using eCommerce.Payments.WayForPay.Exceptions;
using eCommerce.Persistence;

using MediatR;

namespace eCommerce.Application.Payments.Handlers
{
    internal class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, object>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly WayForPay _wayForPay;

        public GetPaymentQueryHandler(IOrderRepository orderRepository, WayForPay wayForPay)
        {
            _orderRepository = orderRepository;
            _wayForPay = wayForPay;
        }

        public async Task<object> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderAsync(request.OrderId);

            if (order == null)
            {
                throw new OrderNotFoundException(request.OrderId);
            }

            try
            {
                return await _wayForPay.GetPaymentAsync(request.OrderId);
            }
            catch (Exception e) when (e is TransactionNotFoundException)
            {
                throw new OrderNotFoundException(request.OrderId);
            }
        }
    }
}
