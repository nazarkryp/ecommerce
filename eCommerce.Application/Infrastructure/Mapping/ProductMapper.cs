using System.Collections.Generic;
using System.Linq;

using eCommerce.Domain.Products;
using eCommerce.Request.Dtos.Products;

namespace eCommerce.Application.Infrastructure.Mapping
{
    internal static class ProductMapper
    {
        public static IEnumerable<ProductResponse> Map(this IEnumerable<Product> products)
            => products.Select(Map);
        public static ProductResponse Map(this Product product)
            => new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUri = product.ImageUri
            };
    }
}
