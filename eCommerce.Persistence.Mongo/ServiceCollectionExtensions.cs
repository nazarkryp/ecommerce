using eCommerce.Persistence.Mongo.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Persistence.Mongo
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
