using System;
using System.Linq;
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

            var order = await _orderRepository.GetOrderAsync(shoppingCard.Id) ?? new Order
            {
                OrderId = Guid.NewGuid().ToString("N"),
                ShoppingCartId = request.ShoppingCartId,
                State = OrderState.Open,
                Amount = shoppingCard.Items.Sum(e => e.Product.Price)
            };

            await _orderRepository.SaveOrderAsync(order);

            return new CreateOrderResult
            {
                OrderId = order.OrderId
            };
        }
    }
}
