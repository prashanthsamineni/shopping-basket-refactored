using System;

namespace ShoppingBasket.Domain.VoucherStrategy
{
    public class ApplyVoucherOnBasketTotal : IApplyVoucher
    {
        private const string VoucherFailure = "Voucher {0} couldnt be applied as the basket threshold is not met. Please buy an extra amount of {1}";
        private const string VoucherSuccess = "Voucher {0} is successfully applied.";

        /// <summary>
        /// Totals the discount price.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <returns></returns>
        public ShoppingCart TotalDiscountPrice(ShoppingCart shoppingCart)
        {
            if (shoppingCart.TotalCostAfterVoucherApplied == 0)
            {
                shoppingCart.TotalCostAfterVoucherApplied = shoppingCart.TotalCost;
            }
            
            if (shoppingCart.TotalCost > 50M)
            {
                shoppingCart.TotalCostAfterVoucherApplied = shoppingCart.TotalCostAfterVoucherApplied - shoppingCart.Voucher.DiscountCost;
                shoppingCart.Message = string.Format(VoucherSuccess, shoppingCart.Voucher.Code);
            }
            else
            {
                shoppingCart.Message = string.Format(VoucherFailure, shoppingCart.Voucher.Code,
                                                     (50.01M - shoppingCart.TotalCost));
            }
            return shoppingCart;
        }

    }
}