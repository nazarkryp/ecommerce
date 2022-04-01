using System.Threading;
using System.Threading.Tasks;

using eCommerce.Application.Exceptions;
using eCommerce.Application.ShoppingCarts.Commands;
using eCommerce.Persistence;

using MediatR;

namespace eCommerce.Application.ShoppingCarts.Handlers
{
    internal class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand, Unit>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public RemoveItemCommandHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<Unit> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartAsync(request.ShoppingCartId);

            if (shoppingCart == null)
            {
                throw new ShoppingCartNotFoundException(request.ShoppingCartId);
            }

            shoppingCart.RemoveItem(request.ItemId);

            await _shoppingCartRepository.SaveShoppingCart(shoppingCart);

            return Unit.Value;
        }
    }
}
