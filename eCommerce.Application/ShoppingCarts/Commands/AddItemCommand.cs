using System;

using MediatR;

namespace eCommerce.Application.ShoppingCarts.Commands
{
    public class AddItemCommand : IRequest
    {
        private AddItemCommand(Guid shoppingCartId, Guid productId)
        {
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
        }

        public Guid ShoppingCartId { get; }

        public Guid ProductId { get; }

        public static AddItemCommand Create(Guid shoppingCartId, Guid productId)
        {
            return new AddItemCommand(shoppingCartId, productId);
        }
    }
}
