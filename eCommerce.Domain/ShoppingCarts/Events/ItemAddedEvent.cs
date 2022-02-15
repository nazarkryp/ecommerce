using eCommerce.Domain.Common;

namespace eCommerce.Domain.ShoppingCarts.Events
{
    internal class ItemAddedEvent : IEvent
    {
        public ShoppingCartItem Item { get; set; }
    }
}
