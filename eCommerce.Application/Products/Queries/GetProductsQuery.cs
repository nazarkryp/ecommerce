using eCommerce.Request.Dtos.Common;
using eCommerce.Request.Dtos.Products;

using MediatR;

namespace eCommerce.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<CollectionResponse<ProductResponse>>
    {
        private GetProductsQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }

        public int Page { get; }

        public int Size { get; }

        public static GetProductsQuery Create(int page, int size)
        {
            return new GetProductsQuery(page, size);
        }
    }
}
