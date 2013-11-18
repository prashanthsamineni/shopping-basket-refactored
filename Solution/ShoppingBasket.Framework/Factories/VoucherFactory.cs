using System.Collections.Generic;
using ShoppingBasket.Domain;

namespace ShoppingBasket.Framework.Factories
{
    public static class VoucherFactory
    {
        public static List<Voucher> Vouchers;
        
        /// <summary>
        /// Initializes the <see cref="VoucherFactory"/> class.
        /// </summary>
        static VoucherFactory()
        {
            Vouchers = new List<Voucher>
                           {
                               new Voucher()
                                   {
                                       Code = "XXX-XXXX",
                                       DiscountCost = 5M,
                                       Reason = "Buy More than 50 GBP to get 5 GBP Discount, this voucher will be applied only on products excluding gift vouchers.",
                                       VoucherType = VoucherType.AppliedOnlyForProductsExcludingGiftVouchers
                                   },
                               new Voucher()
                                   {
                                       Code = "YYY-YYYY",
                                       DiscountCost = 5M,
                                       Reason = "Buy More than 50 GBP to get 5 GBP Discount, this voucher will be applied on the basket total.",
                                       VoucherType = VoucherType.AppliedForBasketTotal
                                   }
                           };
        }
    }
}
