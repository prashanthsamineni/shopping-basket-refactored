using ShoppingBasket.Domain;
using ShoppingBasket.Framework;

namespace ShoppingBasket.Tasks.Contracts
{
    public interface IVoucherRepository : IRepository<Voucher>
    {
        /// <summary>
        /// Gets the voucher by voucher code.
        /// </summary>
        /// <param name="voucherCode">The voucher code.</param>
        /// <returns>The voucher.</returns>
        Voucher GetVoucherByVoucherCode(string voucherCode);
    }
}