using System.Collections.Generic;
using ShoppingBasket.Domain;

namespace ShoppingBasket.Client.Contracts
{
    public interface IVoucherTasks
    {
        /// <summary>
        /// Gets all vouchers.
        /// </summary>
        /// <returns>List of vouchers</returns>
        List<Voucher> GetAllVouchers();

        /// <summary>
        /// Gets the voucher by code.
        /// </summary>
        /// <param name="theVoucherCode">The voucher code.</param>
        /// <returns>The voucher.</returns>
        Voucher GetVoucherByCode(string theVoucherCode);
    }
}