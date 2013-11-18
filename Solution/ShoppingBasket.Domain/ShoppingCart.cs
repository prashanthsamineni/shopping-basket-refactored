using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Domain.Shared;
using ShoppingBasket.Domain.VoucherStrategy;

namespace ShoppingBasket.Domain
{
    /// <summary>
    /// Shopping cart class.
    /// </summary>
    public class ShoppingCart : BaseDomain
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCart"/> class.
        /// </summary>
        public ShoppingCart()
        {
            Items = new List<Item>();
        }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public IList<Item> Items { get; set; }

        /// <summary>
        /// Gets or sets the voucher.
        /// </summary>
        /// <value>
        /// The voucher.
        /// </value>
        public Voucher Voucher { get; set; }

        /// <summary>
        /// Gets the total cost.
        /// </summary>
        public decimal TotalCost
        {
            get { return Items.Sum(x => x.TotalCost); }
        }

        /// <summary>
        /// Gets the total cost excluding gift vouchers.
        /// </summary>
        public decimal TotalCostExcludingGiftVouchers
        {
            get { return Items.Where(x => x.Product.IsGiftVoucher == false).Sum(x => x.TotalCost); }
        }

        /// <summary>
        /// Gets the total cost after discount.
        /// </summary>
        public decimal TotalCostAfterDiscount
        {
            get
            {
                var shoppingCart = VoucherStrategyList.StrategyList()[Voucher.VoucherType].TotalDiscountPrice(this);
                Message = shoppingCart.Message;
                return shoppingCart.TotalCostAfterVoucherApplied;
            }
        }

        /// <summary>
        /// Gets or sets the total cost after voucher applied.
        /// </summary>
        /// <value>
        /// The total cost after voucher applied.
        /// </value>
        public decimal TotalCostAfterVoucherApplied { get; set; }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        public string Message { get; set; }
    }
}
