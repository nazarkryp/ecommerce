using System;

using MediatR;

namespace eCommerce.Application.ShoppingCarts.Commands
{
    public class RemoveItemCommand : IRequest
    {
        private RemoveItemCommand(Guid shoppingCartId, Guid itemId)
        {
            ShoppingCartId = shoppingCartId;
            ItemId = itemId;
        }

        public Guid ShoppingCartId { get; }

        public Guid ItemId { get; }

        public static RemoveItemCommand Create(Guid shoppingCartId, Guid itemId)
        {
            return new RemoveItemCommand(shoppingCartId, itemId);
        }
    }
}
