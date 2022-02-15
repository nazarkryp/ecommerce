using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using eCommerce.Domain.Products;

namespace eCommerce.Persistence
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(int page, int size);

        Task<Product> GetProductAsync(Guid productId);
    }
}
