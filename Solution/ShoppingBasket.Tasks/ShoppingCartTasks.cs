using ShoppingBasket.Client.Contracts;
using ShoppingBasket.Domain;
using ShoppingBasket.Tasks.Contracts;

namespace ShoppingBasket.Tasks
{
    public class ShoppingCartTasks : IShoppingCartTasks
    {
        /// <summary>
        /// Shopping cart repository.
        /// </summary>
        private IShoppingCartRepository shoppingCartRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartTasks"/> class.
        /// </summary>
        /// <param name="shoppingCartRepository">The shopping cart repository.</param>
        public ShoppingCartTasks(IShoppingCartRepository shoppingCartRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
        }

        /// <summary>
        /// Adds to shopping cart.
        /// </summary>
        /// <param name="cartItem">The cart item.</param>
        /// <returns>The shopping cart.</returns>
        public ShoppingCart AddToShoppingCart(Item cartItem)
        {
           return this.shoppingCartRepository.AddItem(cartItem);
        }
    }
}
