using System.Collections.Generic;

namespace ShoppingBasket.Framework
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);

        /// <summary>
        /// Removes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(T entity);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The list of all entities.</returns>
        IEnumerable<T> GetAll();
    }
}