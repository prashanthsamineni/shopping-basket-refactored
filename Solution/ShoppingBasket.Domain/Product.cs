using ShoppingBasket.Domain.Shared;

namespace ShoppingBasket.Domain
{
    public class Product : GiftVoucherDecorator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product()
        {
            this.IsGiftVoucher = false;
        }
    }
}
