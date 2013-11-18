using System;
using System.Collections.Generic;
using ShoppingBasket.Domain;
using ShoppingBasket.Framework;
using ShoppingBasket.Framework.Factories;
using ShoppingBasket.Tasks.Contracts;

namespace ShoppingBasket.Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ShoppingCart GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ShoppingCart> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="shoppingCartItem">The shopping cart item.</param>
        /// <returns>
        /// The ShoppingCart.
        /// </returns>
        public ShoppingCart AddItem(Item shoppingCartItem)
        {
            shoppingCartItem.Id = Utilities.GenerateRandomNumber();
            var shoppingCart = ShoppingCartFactory.ShoppingCart;
            shoppingCart.Items.Add(shoppingCartItem);
            return shoppingCart;
        }
    }
}