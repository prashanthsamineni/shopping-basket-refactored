using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Domain.VoucherStrategy
{
    public static class VoucherStrategyList
    {
        /// <summary>
        /// List of strategies.
        /// </summary>
        /// <returns>The dictionary of voucher strategy.</returns>
        public static Dictionary<VoucherType, IApplyVoucher> StrategyList()
        {
            var voucherStrategies = new Dictionary<VoucherType, IApplyVoucher>
                                        {
                                            {
                                                VoucherType.AppliedForBasketTotal, 
                                                new ApplyVoucherOnBasketTotal()
                                            },
                                            {
                                                VoucherType.AppliedOnlyForProductsExcludingGiftVouchers,
                                                new ApplyVoucherOnBasketExcludingGiftVouchers()
                                            }
                                        };

            return voucherStrategies;
        }
    }
}
