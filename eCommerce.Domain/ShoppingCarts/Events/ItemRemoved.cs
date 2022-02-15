using eCommerce.Domain.Common;

namespace eCommerce.Domain.ShoppingCarts.Events
{
    internal class ItemRemoved : IEvent
    {
        public ShoppingCartItem Item { get; set; }
    }
}
