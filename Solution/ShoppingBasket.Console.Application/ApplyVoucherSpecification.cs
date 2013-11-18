using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using ShoppingBasket.Domain;

namespace ShoppingBasket.ConsoleApplication
{
    public class ApplyVoucherSpecification : Specification<Program>
    {
        protected static ShoppingCart the_shopping_cart;

        protected static Voucher the_voucher;

        Establish context = () =>
        {
            the_shopping_cart = new ShoppingCart();
            the_shopping_cart.Items.Add(new Item(){Product = new Product(){Cost = 100}, Id= 21, Quantity = 1});
        };

        
    }
}