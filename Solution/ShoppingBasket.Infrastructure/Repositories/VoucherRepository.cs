using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Domain;
using ShoppingBasket.Framework.Factories;
using ShoppingBasket.Tasks.Contracts;

namespace ShoppingBasket.Infrastructure.Repositories
{
    public class VoucherRepository : Repository<Voucher>, IVoucherRepository
    {
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Voucher GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(Voucher entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(Voucher entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The list of vouchers.</returns>
        public IEnumerable<Voucher> GetAll()
        {
            return VoucherFactory.Vouchers;
        }

        /// <summary>
        /// Gets the voucher by voucher code.
        /// </summary>
        /// <param name="voucherCode">The voucher code.</param>
        /// <returns>
        /// The voucher.
        /// </returns>
        public Voucher GetVoucherByVoucherCode(string voucherCode)
        {
           return VoucherFactory.Vouchers.Where(x => x.Code == voucherCode).FirstOrDefault();
        }
    }
}