using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using eCommerce.Domain.Products;

namespace eCommerce.Persistence.Mongo.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apple iPhone 12 Pro",
                Price = 1200.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Macbook Pro 2019",
                Price = 2599.69M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "NZXT Kraken x63",
                Price = 250.69M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "NVidia GeForce RTX 3070",
                Price = 1500.69M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Razer Blade 14",
                Price = 2200.69M
            }
        };

        public Task<IEnumerable<Product>> GetProductsAsync(int page, int size)
        {
            return Task.FromResult(Products.AsEnumerable());
        }

        public Task<Product> GetProductAsync(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
