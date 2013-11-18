using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using Rhino.Mocks;
using ShoppingBasket.Client.Contracts;
using ShoppingBasket.Domain;
using ShoppingBasket.Domain.Shared;

namespace ShoppingBasket.ConsoleApplication.ProgramSpecs
{
    public class When_Product_Tasks_Is_Asked_To_Get_All_Products : Specification<Program>
    {
        private static IProductTasks the_product_tasks;

        private static List<GenericProduct> the_products;

        private Establish context = () =>
                                        {
                                            the_product_tasks = DependencyOf<IProductTasks>();
                                            the_products = new List<GenericProduct> {new Product()};
                                            the_product_tasks.Stub(x => x.GetAllProducts()).Return(the_products);
                                        };

        private Because of = () => subject.GetAllProducts();

        private It should_ask_product_tasks_to_get_all_the_products = () => the_products.Count.ShouldEqual(1);
    }
}
