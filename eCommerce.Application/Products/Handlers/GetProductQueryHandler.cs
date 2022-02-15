using System.Threading;
using System.Threading.Tasks;

using eCommerce.Application.Exceptions;
using eCommerce.Application.Infrastructure.Mapping;
using eCommerce.Application.Products.Queries;
using eCommerce.Persistence;
using eCommerce.Request.Dtos.Products;

using MediatR;

namespace eCommerce.Application.Products.Handlers
{
    internal class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductAsync(request.ProductId);

            if (product == null)
            {
                throw new ProductNotFoundException(request.ProductId);
            }

            return product.Map();
        }
    }
}
