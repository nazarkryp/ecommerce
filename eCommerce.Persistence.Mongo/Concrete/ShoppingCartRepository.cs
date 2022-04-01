using System;
using System.Linq;
using System.Threading.Tasks;

using eCommerce.Domain.ShoppingCarts;
using eCommerce.Persistence.Mongo.Infrastructure.Serialization;

using MongoDB.Driver;

namespace eCommerce.Persistence.Mongo.Concrete
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly MongoContainer _container;
        private readonly IEventSerializer _eventSerializer;

        public ShoppingCartRepository(MongoContainer container, IEventSerializer eventSerializer)
        {
            _container = container;
            _eventSerializer = eventSerializer;
        }

        public async Task<ShoppingCart?> GetShoppingCartAsync(Guid shoppingCartId)
        {
            var events = await _container.ShoppingCartEvents.Find(e => e.StreamId == shoppingCartId).ToListAsync();

            if (events.Count == 0)
            {
                return null;
            }

            var domainEvents = events.Select(_eventSerializer.Deserialize).ToArray();

            return ShoppingCart.Aggregate(domainEvents);
        }

        public async Task SaveShoppingCart(ShoppingCart shoppingCart)
        {
            var eventsToStore = shoppingCart.Events.Where(e => e.EventId == Guid.Empty).ToList();

            foreach (var @event in eventsToStore)
            {
                @event.EventId = Guid.NewGuid();
            }

            var storedEvents = eventsToStore.Select(@event => _eventSerializer.Serialize(shoppingCart.Id, @event));

            await _container.ShoppingCartEvents.InsertManyAsync(storedEvents);
        }
    }
}
