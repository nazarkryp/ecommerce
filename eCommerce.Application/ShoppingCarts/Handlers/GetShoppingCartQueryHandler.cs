using System.Threading;
using System.Threading.Tasks;

using eCommerce.Application.Infrastructure.Mapping;
using eCommerce.Application.ShoppingCarts.Queries;
using eCommerce.Persistence;
using eCommerce.Request.Dtos.ShoppingCarts;

using MediatR;

namespace eCommerce.Application.ShoppingCarts.Handlers
{
    internal class GetShoppingCartQueryHandler : IRequestHandler<GetShoppingCartQuery, ShoppingCartResponse>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public GetShoppingCartQueryHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<ShoppingCartResponse> Handle(GetShoppingCartQuery request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartAsync(request.ShoppingCartId);

            return shoppingCart.Map();
        }
    }
}
