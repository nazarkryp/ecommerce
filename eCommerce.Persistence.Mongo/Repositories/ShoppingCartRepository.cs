using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using eCommerce.Domain.Common;
using eCommerce.Domain.ShoppingCarts;

namespace eCommerce.Persistence.Mongo.Repositories
{
    internal class ShoppingCartRepository : IShoppingCartRepository
    {
        private static readonly Dictionary<Guid, List<IEvent>> Events = new Dictionary<Guid, List<IEvent>>();

        public Task<ShoppingCart> GetShoppingCartAsync(Guid shoppingCartId)
        {
            if (!Events.TryGetValue(shoppingCartId, out var events))
            {
                throw new Exception("ShoppingCart not found");
            }

            var shoppingCart = ShoppingCart.Aggregate(events.ToArray());

            return Task.FromResult(shoppingCart);
        }

        public Task SaveShoppingCart(ShoppingCart shoppingCart)
        {
            if (Events.TryGetValue(shoppingCart.Id, out var events))
            {
                var append = shoppingCart.Events.Where(e => !events.Contains(e));
                events.AddRange(append);
            }
            else
            {
                Events.Add(shoppingCart.Id, shoppingCart.Events.ToList());
            }

            return Task.CompletedTask;
        }
    }
}
