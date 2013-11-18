using System;

namespace ShoppingBasket.Domain
{
    using ShoppingBasket.Domain.Shared;

    /// <summary>
    /// This the order class which contains the product items and its quantity.
    /// </summary>
    public class Item : BaseDomain
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public GenericProduct Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets the total cost.
        /// </summary>
        public Decimal TotalCost
        {
            get { return this.Product.Cost * Quantity; }
        }

        /// <summary>
        /// Generates the random number.
        /// </summary>
        /// <returns></returns>
        private static int GenerateRandomNumber()
        {
            var random = new Random(1);
            return random.Next(100);
        }
    }
}
