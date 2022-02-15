using System;
using System.Threading;
using System.Threading.Tasks;

using eCommerce.Application.ShoppingCarts.Commands;
using eCommerce.Domain.ShoppingCarts;
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

            var product = await _productRepository.GetProductAsync(request.ProductId);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            shoppingCart.AddItem(new ShoppingCartItem
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                Price = product.Price,
                ProductId = request.ProductId,
            });

            await _shoppingCartRepository.SaveShoppingCart(shoppingCart);

            return Unit.Value;
        }
    }
}
