using System;

using eCommerce.Request.Dtos.ShoppingCarts;

using MediatR;

namespace eCommerce.Application.ShoppingCarts.Queries
{
    public class GetShoppingCartQuery : IRequest<ShoppingCartResponse>
    {
        private GetShoppingCartQuery(Guid shoppingCartId)
        {
            ShoppingCartId = shoppingCartId;
        }

        public Guid ShoppingCartId { get; set; }

        public static GetShoppingCartQuery Create(Guid shoppingCartId)
        {
            return new GetShoppingCartQuery(shoppingCartId);
        }
    }
}
