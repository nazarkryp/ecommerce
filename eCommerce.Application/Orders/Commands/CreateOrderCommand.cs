using System;

using eCommerce.Request.Dtos.Orders;

using MediatR;

namespace eCommerce.Application.Orders.Commands
{
    public class CreateOrderCommand : IRequest<CreateOrderResult>
    {
        private CreateOrderCommand(Guid shoppingCartId)
        {
            ShoppingCartId = shoppingCartId;
        }

        public Guid ShoppingCartId { get; }

        public static CreateOrderCommand Create(Guid shoppingCardId)
        {
            return new CreateOrderCommand(shoppingCardId);
        }
    }
}
