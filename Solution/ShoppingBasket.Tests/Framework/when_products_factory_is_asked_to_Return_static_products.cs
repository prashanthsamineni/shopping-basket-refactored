using System.Collections.Generic;
using Machine.Specifications;
using ShoppingBasket.Domain.Shared;
using ShoppingBasket.Framework;

namespace ShoppingBasket.Tests.Framework
{
    public class when_products_factory_is_asked_to_Return_static_products
    {
        private static List<GenericProduct> the_products;

        private Establish context = () =>
                                        {
                                            the_products = new List<GenericProduct>();
                                        };
        private Because of = () => the_products = ProductFactory.Products;
        private It should_return_the_list_of_products = () => the_products.Count.ShouldEqual(4);
    }
}
