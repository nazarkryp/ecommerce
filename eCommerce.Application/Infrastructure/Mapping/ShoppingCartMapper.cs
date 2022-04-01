using System.Collections.Generic;
using System.Linq;

using eCommerce.Domain.ShoppingCarts;

namespace eCommerce.Application.Infrastructure.Mapping
{
    internal static class ShoppingCartMapper
    {
        public static eCommerce.Request.Dtos.ShoppingCarts.ShoppingCartResponse Map(this ShoppingCart shoppingCart)
        {
            return new eCommerce.Request.Dtos.ShoppingCarts.ShoppingCartResponse
            {
                Id = shoppingCart.Id,
                Items = shoppingCart.Items.Map()
            };
        }

        private static eCommerce.Request.Dtos.ShoppingCarts.ShoppingCartItemResponse[] Map(this IReadOnlyCollection<ShoppingCartItem> items)
        {
            return items.Select(e => new eCommerce.Request.Dtos.ShoppingCarts.ShoppingCartItemResponse
            {
                Id = e.Id,
                Product = e.Product.Map(),
                Quantity = e.Quantity
            }).ToArray();
        }
    }
}
