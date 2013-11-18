using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Domain.Shared;
using ShoppingBasket.Framework;
using ShoppingBasket.Tasks.Contracts;

namespace ShoppingBasket.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Gets the entity by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The product.</returns>
        public GenericProduct GetById(int id)
        {
            return ProductFactory.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(GenericProduct entity)
        {
            new List<GenericProduct> { entity };
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(GenericProduct entity)
        {
            var products = new List<GenericProduct>();
            products.Remove(entity);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The list of all generic products.</returns>
        public IEnumerable<GenericProduct> GetAll()
        {
            return ProductFactory.Products.OrderBy(product => product.Id);
        }
    }
}
