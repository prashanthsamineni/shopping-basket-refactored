namespace ShoppingBasket.Domain.VoucherStrategy
{
    public interface IApplyVoucher
    {
        /// <summary>
        /// Totals the discount price.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <returns></returns>
        ShoppingCart TotalDiscountPrice(ShoppingCart shoppingCart);
    }
}
