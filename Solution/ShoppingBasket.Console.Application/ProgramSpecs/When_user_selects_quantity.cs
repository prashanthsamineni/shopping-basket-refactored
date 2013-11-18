using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using ShoppingBasket.Domain;
using ShoppingBasket.Domain.Shared;

namespace ShoppingBasket.ConsoleApplication.ProgramSpecs
{
    public class When_user_selects_quantity : Specification<Program>
    {
        private static GenericProduct the_product;
        private static string the_quantity;
        private const int QUANTITY = 1;

        private static Item the_shopping_cart_item;

        private const string THEPRODUCTNAME = "test";

        private Establish context = () =>
        {
            the_product = new GenericProduct(){Name = THEPRODUCTNAME};
            the_quantity = QUANTITY.ToString();
        };

        private Because of = () => the_shopping_cart_item = subject.MapUserInputToDomain(the_product, the_quantity);
        private It should_map_user_inputs_to_shopping_cart_item = () => the_shopping_cart_item.ShouldNotBeNull();

        private It should_contain_the_same_quantity_as_user_selected =
            () => the_shopping_cart_item.Quantity.ShouldEqual(QUANTITY);

        private It should_contain_the_same_product_as_user_selected =
            () => the_shopping_cart_item.Product.Name.ShouldEqual(THEPRODUCTNAME);
    }
}