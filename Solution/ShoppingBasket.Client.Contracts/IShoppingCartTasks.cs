using ShoppingBasket.Domain;
using ShoppingBasket.Domain.Shared;

namespace ShoppingBasket.Client.Contracts
{
    public interface IShoppingCartTasks
    {
        /// <summary>
        /// Adds to shopping cart.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>The shopping cart.</returns>
        ShoppingCart AddToShoppingCart(Item product);
    }
}