using System.Collections.Generic;
using ShoppingBasket.Domain.Shared;

namespace ShoppingBasket.Client.Contracts
{
    public interface IProductTasks
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>List of products.</returns>
        IEnumerable<GenericProduct> GetAllProducts();

        /// <summary>
        /// Gets the product by id.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>The generic product.</returns>
        GenericProduct GetProductById(int i);
    }
}