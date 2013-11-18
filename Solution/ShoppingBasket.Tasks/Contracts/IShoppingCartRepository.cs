using ShoppingBasket.Domain;
using ShoppingBasket.Domain.Shared;
using ShoppingBasket.Framework;

namespace ShoppingBasket.Tasks.Contracts
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="shoppingCartItem">The shopping cart item.</param>
        /// <returns>The ShoppingCart.</returns>
        ShoppingCart AddItem(Item shoppingCartItem);
    }
}