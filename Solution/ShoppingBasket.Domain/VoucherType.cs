namespace ShoppingBasket.Domain
{
    public enum VoucherType
    {
        /// <summary>
        /// This type of voucher can be applied for the complete basket total.
        /// </summary>
        AppliedForBasketTotal = 1,

        /// <summary>
        /// This type of voucher can only be applied on the basket with products excluding gift vouchers.
        /// </summary>
        AppliedOnlyForProductsExcludingGiftVouchers = 2
    }
}