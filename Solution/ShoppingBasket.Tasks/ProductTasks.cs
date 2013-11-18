using System;
using System.Collections.Generic;
using ShoppingBasket.Client.Contracts;
using ShoppingBasket.Domain.Shared;
using ShoppingBasket.Tasks.Contracts;

namespace ShoppingBasket.Tasks
{
    public class ProductTasks : IProductTasks
    {
        private IProductRepository productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTasks"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public ProductTasks(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>
        /// List of products.
        /// </returns>
        public IEnumerable<GenericProduct> GetAllProducts()
        {
           return this.productRepository.GetAll();
        }

        /// <summary>
        /// Gets the product by id.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <returns>The generic product.</returns>
        public GenericProduct GetProductById(int productId)
        {
            return this.productRepository.GetById(productId);
        }
    }
}
