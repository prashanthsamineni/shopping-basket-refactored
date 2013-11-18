using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Client.Contracts;
using ShoppingBasket.Domain;
using ShoppingBasket.Tasks.Contracts;

namespace ShoppingBasket.Tasks
{
    public class VoucherTasks : IVoucherTasks
    {
        private IVoucherRepository voucherRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="VoucherTasks"/> class.
        /// </summary>
        /// <param name="voucherRepository">The voucher repository.</param>
        public VoucherTasks(IVoucherRepository voucherRepository)
        {
            this.voucherRepository = voucherRepository;
        }

        /// <summary>
        /// Gets all vouchers.
        /// </summary>
        /// <returns>
        /// List of vouchers
        /// </returns>
        public List<Voucher> GetAllVouchers()
        {
            return voucherRepository.GetAll().ToList();
        }

        /// <summary>
        /// Gets the voucher by code.
        /// </summary>
        /// <param name="voucherCode">The voucher code.</param>
        /// <returns>The voucher.</returns>
        public Voucher GetVoucherByCode(string voucherCode)
        {
            return voucherRepository.GetVoucherByVoucherCode(voucherCode);
        }
    }
}