using ShoppingBasket.Domain;

namespace ShoppingBasket.Framework.Factories
{
    public static class ShoppingCartFactory
    {
        public static ShoppingCart ShoppingCart;

        /// <summary>
        /// Initializes the <see cref="ShoppingCartFactory"/> class.
        /// </summary>
        static ShoppingCartFactory()
        {
            ShoppingCart = new ShoppingCart();
        }
    }
}
