using System.Threading;
using System.Threading.Tasks;

using eCommerce.Application.ShoppingCarts.Commands;
using eCommerce.Domain.ShoppingCarts;
using eCommerce.Persistence;
using eCommerce.Request.Dtos.ShoppingCarts;

using MediatR;

namespace eCommerce.Application.ShoppingCarts.Handlers
{
    internal class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, CreateShoppingCartResult>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public CreateShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<CreateShoppingCartResult> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var shoppingCart = ShoppingCart.Create();

            await _shoppingCartRepository.SaveShoppingCart(shoppingCart);

            return new CreateShoppingCartResult
            {
                Id = shoppingCart.Id
            };
        }
    }
}
