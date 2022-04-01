using System.Threading;
using System.Threading.Tasks;

using eCommerce.Application.Exceptions;
using eCommerce.Application.ShoppingCarts.Commands;
using eCommerce.Persistence;

using MediatR;

namespace eCommerce.Application.ShoppingCarts.Handlers
{
    internal class AddItemCommandHandler : IRequestHandler<AddItemCommand, Unit>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public AddItemCommandHandler(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartAsync(request.ShoppingCartId);

            if (shoppingCart == null)
            {
                throw new ShoppingCartNotFoundException(request.ShoppingCartId);
            }

            var product = await _productRepository.GetProductAsync(request.ProductId);

            if (product == null)
            {
                throw new ProductNotFoundException(request.ProductId);
            }

            shoppingCart.AddItem(product);

            await _shoppingCartRepository.SaveShoppingCart(shoppingCart);

            return Unit.Value;
        }
    }
}
