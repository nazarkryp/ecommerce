using System;
using System.Threading;
using System.Threading.Tasks;

using eCommerce.Application.Exceptions;
using eCommerce.Application.Orders.Commands;
using eCommerce.Domain.Orders;
using eCommerce.Persistence;
using eCommerce.Request.Dtos.Orders;

using MediatR;

namespace eCommerce.Application.Orders.Handlers
{
    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IShoppingCartRepository shoppingCartRepository, IOrderRepository orderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _orderRepository = orderRepository;
        }

        public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var shoppingCard = await _shoppingCartRepository.GetShoppingCartAsync(request.ShoppingCartId);

            if (shoppingCard == null)
            {
                throw new ShoppingCartNotFoundException(request.ShoppingCartId);
            }

            var order = new Order
            {
                OrderId = Guid.NewGuid().ToString("N"),
                ShoppingCartId = request.ShoppingCartId,
                State = OrderState.Open
            };

            await _orderRepository.SaveOrderAsync(order);

            return new CreateOrderResult
            {
                OrderId = order.OrderId
            };
        }
    }
}
