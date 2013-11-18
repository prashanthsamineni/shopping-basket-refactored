using Machine.Specifications;
using ShoppingBasket.Domain;
using ShoppingBasket.Framework.Factories;

namespace ShoppingBasket.Tests.Framework
{
    public class when_shopping_cart_factory_is_asked_to_Return_static_shopping_cart
    {
        private static ShoppingCart the_shopping_cart;
        private Because of = () => the_shopping_cart = ShoppingCartFactory.ShoppingCart;
        private It should_return_the_list_of_vouchers = () => the_shopping_cart.ShouldNotBeNull();
    }
}
