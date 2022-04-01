using System.Threading;
using System.Threading.Tasks;

using eCommerce.Persistence.Mongo.Infrastructure;

using MongoDB.Driver;

namespace eCommerce.Persistence.Mongo
{
    public class MongoContainer
    {
        private readonly IMongoClient _mongoClient;
        public MongoContainer()
        {
            _mongoClient = new MongoClient("mongodb+srv://nazarkryp:qwerty123456@cluster0.zoasx.mongodb.net/test");
            var mongoDatabase = _mongoClient.GetDatabase("ecommerce");

            ShoppingCartEvents = mongoDatabase.GetCollection<StoredEvent>("shoppingcart");
        }

        public async Task AppendStreamAsync(StoredEvent[] events, CancellationToken token = default)
        {
            using var session = await _mongoClient.StartSessionAsync(cancellationToken: token);

        }

        public IMongoCollection<StoredEvent> ShoppingCartEvents { get; }
    }
}
