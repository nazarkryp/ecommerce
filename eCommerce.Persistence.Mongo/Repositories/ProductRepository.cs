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
                Name = "NZXT Kraken x63",
                Price = 250.69M,
                ImageUri = "https://content.rozetka.com.ua/goods/images/big/21500247.jpg"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "NVidia GeForce RTX 3070",
                Price = 1500.69M,
                ImageUri = "https://img.etasawaq.com/2021/07/3070nonoc.jpg"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Razer Blade 14",
                Price = 2200.69M,
                ImageUri = "https://www.pcworld.com/wp-content/uploads/2021/09/razer-blade-14-primary-100900019-orig.jpg?quality=50&strip=all&w=1024"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apple iPhone 12 Pro",
                Price = 1200.99M,
                ImageUri = "https://loopnew.com/wp-content/uploads/2020/11/apple-iphone-12-pro-2.jpg"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Macbook Pro 2019",
                Price = 2599.69M,
                ImageUri = "https://www.notebookcheck-ru.com/uploads/tx_nbc2/Bildschirmfoto_2019-10-01_um_12.20.11.png"

            }
        };

        public Task<IEnumerable<Product>> GetProductsAsync(int page, int size)
        {
            return Task.FromResult(Products.AsEnumerable());
        }

        public Task<Product?> GetProductAsync(Guid productId)
        {
            var product = Products.FirstOrDefault(e => e.Id == productId);

            return Task.FromResult<Product?>(product);
        }
    }
}
