namespace ShoppingBasket.Domain
{
    public class GiftVoucher : GiftVoucherDecorator
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is gift voucher.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is gift voucher; otherwise, <c>false</c>.
        /// </value>
        public override bool IsGiftVoucher
        {
            get
            {
                return true;
            }
        }
    }
}