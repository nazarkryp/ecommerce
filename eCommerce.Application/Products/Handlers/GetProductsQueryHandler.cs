using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using eCommerce.Application.Infrastructure.Mapping;
using eCommerce.Application.Products.Queries;
using eCommerce.Domain.Products;
using eCommerce.Persistence;
using eCommerce.Request.Dtos.Common;
using eCommerce.Request.Dtos.Products;

using MediatR;

namespace eCommerce.Application.Products.Handlers
{
    internal class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, CollectionResponse<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CollectionResponse<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsAsync(request.Page, request.Size);
            var productList = products as Product[] ?? products.ToArray();

            return new CollectionResponse<ProductResponse>
            {
                Items = productList.Map(),
                Page = request.Page,
                Total = productList.Length,
                Size = request.Size,
            };
        }
    }
}
