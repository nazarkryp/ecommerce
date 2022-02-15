using eCommerce.Request.Dtos.ShoppingCarts;

using MediatR;

namespace eCommerce.Application.ShoppingCarts.Commands
{
    public class CreateShoppingCartCommand : IRequest<CreateShoppingCartResult>
    {
        private CreateShoppingCartCommand()
        {
        }

        public static CreateShoppingCartCommand Create()
        {
            return new CreateShoppingCartCommand();
        }
    }
}
