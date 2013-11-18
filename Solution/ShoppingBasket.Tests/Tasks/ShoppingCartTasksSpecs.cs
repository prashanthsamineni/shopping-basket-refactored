using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using Rhino.Mocks;
using ShoppingBasket.Domain;
using ShoppingBasket.Domain.Shared;
using ShoppingBasket.Tasks;
using ShoppingBasket.Tasks.Contracts;

namespace ShoppingBasket.Tests.Tasks
{
    public class When_shopping_cart_tasks_is_asked_to_add_a_product_to_shopping_cart : Specification<ShoppingCartTasks>
    {
        private static Item the_shopping_cart_item;
        private static IShoppingCartRepository the_shopping_cart_repository;

        private static ShoppingCart the_shopping_cart;

        private const int QUANTITY = 1;

        private const string PRODUCTNAME = "Test";

        private Establish context = () =>
                                        {
                                            the_shopping_cart_item = new Item {Quantity = QUANTITY, Product = new GenericProduct(){Name = PRODUCTNAME}};
                                            the_shopping_cart = new ShoppingCart();
                                            the_shopping_cart.Items.Add(the_shopping_cart_item);
                                            the_shopping_cart_repository = DependencyOf<IShoppingCartRepository>();
                                            the_shopping_cart_repository.Stub(x => x.AddItem(the_shopping_cart_item)).Return(the_shopping_cart);
                                        };

        private Because of = () => subject.AddToShoppingCart(the_shopping_cart_item);
        private It should_add_a_product_to_shopping_cart = () => the_shopping_cart.Items.ShouldNotBeEmpty();
        private It should_contain_the_same_quantity = () => the_shopping_cart.Items[0].Quantity.ShouldEqual(QUANTITY);

        private It should_containt_the_same_product =
            () => the_shopping_cart.Items[0].Product.Name.ShouldEqual(PRODUCTNAME);
    }
}
