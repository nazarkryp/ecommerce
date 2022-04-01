using System;
using System.Threading;
using System.Threading.Tasks;

using eCommerce.Application.Exceptions;
using eCommerce.Application.Orders.Queries;
using eCommerce.Persistence;
using eCommerce.Request.Dtos.Orders;

using MediatR;

namespace eCommerce.Application.Orders.Handlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderAsync(request.OrderId);

            if (order == null)
            {
                throw new OrderNotFoundException(request.OrderId);
            }

            return new OrderResponse
            {
                OrderId = order.OrderId,
                ShoppingCartId = order.ShoppingCartId,
                State = 1
            };
        }
    }
}
