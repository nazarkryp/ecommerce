using System;
using System.Threading.Tasks;

using eCommerce.Domain.ShoppingCarts;

namespace eCommerce.Persistence
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart?> GetShoppingCartAsync(Guid shoppingCartId);

        Task SaveShoppingCart(ShoppingCart shoppingCart);
    }
}
