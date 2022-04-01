using System.Linq;
using System.Reflection;

using eCommerce.Domain.Common;
using eCommerce.Persistence.Mongo.Infrastructure.Serialization;
using eCommerce.Persistence.Mongo.Repositories;

using Microsoft.Extensions.DependencyInjection;
using ShoppingCartRepository = eCommerce.Persistence.Mongo.Concrete.ShoppingCartRepository;

namespace eCommerce.Persistence.Mongo
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddEventStore();

            return services;
        }

        private static IServiceCollection AddEventStore(this IServiceCollection services)
        {
            services.AddScoped<MongoContainer>();
            services.AddSingleton<IEventSerializer, EventSerializer>(_ =>
            {
                var eventTypes = Assembly.GetAssembly(typeof(Event))?.GetTypes()
                    .Where(e => e != typeof(Event) && typeof(Event).IsAssignableFrom(e))
                    .ToDictionary(e => e.Name, e => e);

                return new EventSerializer(eventTypes);
            });

            return services;
        }
    }
}
