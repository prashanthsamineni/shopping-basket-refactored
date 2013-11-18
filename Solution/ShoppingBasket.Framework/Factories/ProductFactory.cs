namespace ShoppingBasket.Framework
{
    using System.Collections.Generic;
    using Domain;
    using Domain.Shared;

    public static class ProductFactory
    {
        public static List<GenericProduct> Products = new List<GenericProduct>();

        /// <summary>
        /// Initializes the <see cref="ProductFactory"/> class.
        /// </summary>
        static ProductFactory()
        {
            Products.Add(new Product() { Cost = 10.50M, Description = "hat", Id = 1, Name = "Hat" });
            Products.Add(new Product() { Cost = 54.65M, Description = "jumper", Id = 2, Name = "Jumper" });
            Products.Add(new Product() { Cost = 3.00M, Description = "inner tube repair kit", Id = 4, Name = "Inner tube repair kit" });
            Products.Add(new GiftVoucher() { Cost = 30.00M, Description = "Gift Voucher", Id = 3, Name = "Gift Voucher" });
        }
    }
}
