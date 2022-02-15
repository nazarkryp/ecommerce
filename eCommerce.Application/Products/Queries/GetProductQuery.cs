using System;

using eCommerce.Request.Dtos.Products;

using MediatR;

namespace eCommerce.Application.Products.Queries
{
    public class GetProductQuery : IRequest<ProductResponse>
    {
        private GetProductQuery(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; }

        public static GetProductQuery Create(Guid productId)
        {
            return new GetProductQuery(productId);
        }
    }
}
