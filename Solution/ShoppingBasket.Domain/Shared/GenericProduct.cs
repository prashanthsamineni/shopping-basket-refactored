namespace ShoppingBasket.Domain.Shared
{
    /// <summary>
    /// Product class.
    /// </summary>
    public class GenericProduct : BaseDomain
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        public decimal Cost { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is gift voucher.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is gift voucher; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsGiftVoucher { get; protected internal set; }
    }
}
