using System.Collections.Generic;
using ShoppingBasket.Framework;
using ShoppingBasket.Domain.Shared;

namespace ShoppingBasket.Tasks.Contracts
{
    public interface IProductRepository : IRepository<GenericProduct>
    {
    }
}
